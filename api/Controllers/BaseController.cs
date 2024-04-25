using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

namespace api.Controllers
{
    [Route("aucusoft/[controller]")]
    public abstract class BaseController<TEntity, TContext> : ControllerBase
        where TEntity : class
        where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseController(TContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        // Абстрактное свойство для указания связей
        protected abstract Expression<Func<TEntity, object>>[] Includes { get; }

        // Абстрактный метод для определения проекции
        protected abstract Expression<Func<TEntity, object>> Projection { get; }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var keyName = _context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties
                          .Select(x => x.Name).Single();

            IQueryable<TEntity> query = _dbSet;

            // Применение связей
            foreach (var include in Includes)
            {
                query = query.Include(include);
            }

            // Выполнение проекции
            var result = await query.Select(Projection)
                .FirstOrDefaultAsync(e => EF.Property<int>(e, keyName) == id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(new { data = new[] { result } });
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetAll(
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 0,
            [FromQuery] string sortBy = null,
            [FromQuery] string sortDirection = "asc",
            [FromQuery] string searchQuery = null,
            [FromQuery] string fieldName = null,
            [FromQuery] string fieldValue = null)
        {
            IQueryable<TEntity> ApplySorting(IQueryable<TEntity> query, string sortBy, string sortDirection)
            {
                var propertyInfo = typeof(TEntity).GetProperty(sortBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (propertyInfo == null)
                {
                    throw new ArgumentException($"Key '{sortBy}' is not a property of type '{typeof(TEntity).Name}'.");
                }

                var parameter = Expression.Parameter(typeof(TEntity), "x");
                var property = Expression.Property(parameter, propertyInfo);
                var lambda = Expression.Lambda<Func<TEntity, object>>(Expression.Convert(property, typeof(object)), parameter);

                query = sortDirection.ToLower() == "asc" ? query.OrderBy(lambda) : query.OrderByDescending(lambda);
                return query;
            }

            IQueryable<TEntity> ApplySearch(IQueryable<TEntity> query, string searchQuery)
            {
                var properties = typeof(TEntity).GetProperties().Where(p => p.PropertyType == typeof(string));

                var searchPredicates = properties.Select(prop => {
                    var parameterExp = Expression.Parameter(typeof(TEntity), "type");
                    var propertyExp = Expression.Property(parameterExp, prop.Name);
                    var method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    var someValue = Expression.Constant(searchQuery, typeof(string));
                    var containsMethodExp = Expression.Call(propertyExp, method, someValue);
                    return Expression.Lambda<Func<TEntity, bool>>(containsMethodExp, parameterExp);
                });

                var combinedExpression = searchPredicates.Aggregate((Expression<Func<TEntity, bool>>)null, (current, predicate) =>
                    current == null ? predicate : Expression.Lambda<Func<TEntity, bool>>(Expression.OrElse(current.Body, Expression.Invoke(predicate, current.Parameters.Single())), current.Parameters));

                if (combinedExpression != null)
                    query = query.Where(combinedExpression);

                return query;
            }
            IQueryable<TEntity> ApplyFieldFilter(IQueryable<TEntity> query, string fieldName, string fieldValue)
            {
                if (!string.IsNullOrEmpty(fieldName) && !string.IsNullOrEmpty(fieldValue))
                {
                    var parameterExp = Expression.Parameter(typeof(TEntity), "type");
                    var propertyExp = Expression.Property(parameterExp, fieldName);
                    var propertyType = ((PropertyInfo)propertyExp.Member).PropertyType;

                    if (propertyType == typeof(string))
                    {
                        MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                        var someValue = Expression.Constant(fieldValue, typeof(string));
                        var containsMethodExp = Expression.Call(propertyExp, method, someValue);

                        var lambda = Expression.Lambda<Func<TEntity, bool>>(containsMethodExp, parameterExp);
                        query = query.Where(lambda);
                    }
                    else if (propertyType == typeof(Nullable<decimal>) || propertyType == typeof(decimal))
                    {
                        var toStringExp = Expression.Call(propertyExp, "ToString", null, null);
                        MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                        var someValue = Expression.Constant(fieldValue, typeof(string));
                        var containsMethodExp = Expression.Call(toStringExp, method, someValue);

                        var lambda = Expression.Lambda<Func<TEntity, bool>>(containsMethodExp, parameterExp);
                        query = query.Where(lambda);
                    }
                }
                return query;
            }

            IQueryable<TEntity> query = _dbSet;

            // Apply includes
            foreach (var include in Includes)
            {
                query = query.Include(include);
            }

            // Apply sorting
            if (!string.IsNullOrEmpty(sortBy))
            {
                query = ApplySorting(query, sortBy, sortDirection);
            }

            // Apply search and field filtering
            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = ApplySearch(query, searchQuery);
            }
            else if (!string.IsNullOrEmpty(fieldName) && !string.IsNullOrEmpty(fieldValue))
            {
                query = ApplyFieldFilter(query, fieldName, fieldValue);
            }

            // Apply projection
            var projectedQuery = query.Select(Projection);

            // Apply pagination
            var data = await projectedQuery.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            var totalItems = await query.CountAsync();

            return Ok(new
            {
                data,
                pageIndex = pageIndex,
                pageSize = pageSize,
                totalPages = (int)Math.Ceiling((double)totalItems / pageSize)
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity item)
        {
            if (item == null)
            {
                return BadRequest("Item is null");
            }

            var existingItem = await _dbSet.FindAsync(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            // Обновляем только те поля, которые были переданы
            var itemProperties = item.GetType().GetProperties();
            foreach (var property in itemProperties)
            {
                var newValue = property.GetValue(item);
                if (newValue != null) // проверяем, что новое значение поля не null
                {
                    var existingValue = property.GetValue(existingItem);
                    if (existingValue != newValue)
                    {
                        property.SetValue(existingItem, newValue);
                    }
                }
            }

            _context.Entry(existingItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _dbSet.AnyAsync(e => (int)e.GetType().GetProperty("ID").GetValue(e) == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity item)
        {
            _dbSet.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetItem", new { id = item.GetType().GetProperty("ID").GetValue(item) }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _dbSet.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
