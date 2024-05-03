using api.Context;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace api.Controllers
{
    [Route("aucusoft/[controller]")]
    [Authorize]
    public abstract class BaseController<TEntity, TContext> : ControllerBase
        where TEntity : class
        where TContext : DbContext
    {
        protected readonly TContext? _context;
        private readonly DbSet<TEntity>? _dbSet;

        public BaseController(TContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        // Абстрактное свойство для указания связей
        protected abstract Expression<Func<TEntity, object>>[] Includes { get; }
        // Абстрактный метод для определения проекции
        protected abstract Expression<Func<TEntity, object>> Projection { get; }
        // Абстрактный метод для получения дополнительных данных
        protected abstract Task<object> GetAdditionalDataAsync();

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var keyName = _context?.Model.FindEntityType(typeof(TEntity))?.FindPrimaryKey()?.Properties
                          .Select(x => x.Name).Single();

            if (keyName == null) return Ok();

            IQueryable<TEntity>? query = _dbSet;

            // Применение связей
            foreach (var include in Includes)
            {
                query = query?.Include(include);
            }
            if (query == null) return Ok();

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
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 1,
            [FromQuery] string? sortBy = null,
            [FromQuery] string sortDirection = "asc",
            [FromQuery] string? searchQuery = null,
            [FromQuery] string? dateFilterType = null,
            [FromQuery] string? fieldName = null,
            [FromQuery] string? fieldValue = null)
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
                    if (method == null) return null;
                    var someValue = Expression.Constant(searchQuery, typeof(string));
                    var containsMethodExp = Expression.Call(propertyExp, method, someValue);
                    return Expression.Lambda<Func<TEntity, bool>>(containsMethodExp, parameterExp);
                });

                var combinedExpression = searchPredicates.Aggregate((Expression<Func<TEntity, bool>>?)null, (current, predicate) =>
                    current == null ? predicate : Expression.Lambda<Func<TEntity, bool>>(Expression.OrElse(current.Body, Expression.Invoke(predicate, current.Parameters.Single())), current.Parameters));

                if (combinedExpression != null)
                    query = query.Where(combinedExpression);

                return query;
            }
            IQueryable<TEntity> ApplyFieldFilter(IQueryable<TEntity> query, string fieldName, string fieldValue)
            {
                if (!string.IsNullOrEmpty(fieldName) && !string.IsNullOrEmpty(fieldValue))
                {
                    var parameterExp = Expression.Parameter(typeof(TEntity), "entity");

                    Expression propertyExp = parameterExp;
                    Type propertyType = null;

                    if (fieldName.EndsWith("Id"))
                    {
                        string navigationPropertyName = fieldName.Remove(fieldName.Length - 2);
                        propertyExp = Expression.PropertyOrField(parameterExp, navigationPropertyName);

                        propertyExp = Expression.PropertyOrField(propertyExp, "Name");
                        propertyType = propertyExp.Type;
                    }
                    else
                    {
                        propertyExp = Expression.PropertyOrField(parameterExp, fieldName);
                        propertyType = propertyExp.Type;
                    }

                    if (propertyType == typeof(DateTime) || propertyType == typeof(DateTime?))
                    {
                        DateTime parsedDate;
                        if (DateTime.TryParse(fieldValue, out parsedDate))
                        {
                            Expression dateFilter;
                            switch (dateFilterType)
                            {
                                case "before":
                                    dateFilter = Expression.LessThan(propertyExp, Expression.Constant(parsedDate, typeof(DateTime?)));
                                    break;
                                case "after":
                                    dateFilter = Expression.GreaterThanOrEqual(propertyExp, Expression.Constant(parsedDate.AddDays(1), typeof(DateTime?)));
                                    break;
                                default: // "on"
                                    var dayAfter = parsedDate.AddDays(1);
                                    dateFilter = Expression.AndAlso(
                                        Expression.GreaterThanOrEqual(propertyExp, Expression.Constant(parsedDate, typeof(DateTime?))),
                                        Expression.LessThan(propertyExp, Expression.Constant(dayAfter, typeof(DateTime?)))
                                    );
                                    break;
                            }
                            var lambda = Expression.Lambda<Func<TEntity, bool>>(dateFilter, parameterExp);
                            query = query.Where(lambda);
                        }
                    }
                    else if (propertyType == typeof(string))
                    {
                        MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                        var someValue = Expression.Constant(fieldValue, typeof(string));
                        var containsMethodExp = Expression.Call(propertyExp, method, someValue);
                        var lambda = Expression.Lambda<Func<TEntity, bool>>(containsMethodExp, new ParameterExpression[] { parameterExp });
                        query = query.Where(lambda);
                    }
                    else
                    {
                        throw new ArgumentException($"Field {fieldName} is not of type string or DateTime and cannot be used for Contains or range operations.");
                    }
                }
                return query;
            }

            try
            {
                IQueryable<TEntity>? query = _dbSet;
                if (query == null) return Ok();

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
                var additional = await GetAdditionalDataAsync();
                var totalItems = await query.CountAsync();

                return Ok(new
                {
                    data,
                    additional,
                    pageIndex,
                    pageSize,
                    totalPages = (int)Math.Ceiling((double)totalItems / pageSize)
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity item)
        {
            if (item == null)
            {
                return BadRequest("Item is null");
            }
            if (_dbSet == null || _context == null) return NotFound();

            var existingItem = await _dbSet.FindAsync(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            var itemProperties = item.GetType().GetProperties();
            foreach (var property in itemProperties)
            {
                var newValue = property.GetValue(item);
                if (newValue != null)
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
                if (!await _dbSet.AnyAsync(e => (int?)e.GetType().GetProperty("ID").GetValue(e) == id))
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
            if (_dbSet == null || _context == null || item == null) return NotFound();

            _dbSet.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetItem", new { id = item.GetType().GetProperty("ID")?.GetValue(item) }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_dbSet == null || _context == null) return NotFound();
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
