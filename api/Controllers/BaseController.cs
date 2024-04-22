using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public class PagedResult<T>
        {
            public IEnumerable<T> Items { get; set; }
            public int TotalItems { get; set; }
            public int TotalPages { get; set; }
            public int CurrentPage { get; set; }
            public int PageSize { get; set; }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetAll(
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 0,
            [FromQuery] string sortBy = null,
            [FromQuery] string sortDirection = "asc")
        {
            IQueryable<TEntity> query = _dbSet;

            // sort property name
            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = typeof(TEntity).GetProperties()
                    .FirstOrDefault(p => p.Name.EndsWith("Id", StringComparison.OrdinalIgnoreCase))?.Name ?? "Id";
            }

            // sorting
            var propertyInfo = typeof(TEntity).GetProperty(sortBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo == null)
            {
                throw new ArgumentException($"Key '{sortBy}' is not a property of type '{typeof(TEntity).Name}'.");
            }

            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var property = Expression.Property(parameter, propertyInfo);
            var lambda = Expression.Lambda<Func<TEntity, object>>(Expression.Convert(property, typeof(object)), parameter);

            query = sortDirection.ToLower() == "asc" ?
                query.OrderBy(lambda) :
                query.OrderByDescending(lambda);

            // pagination
            if (pageIndex > 0 && pageSize > 0)
            {
                var totalItems = await query.CountAsync();
                var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

                query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

                var items = await query.ToListAsync();

                return Ok(new PagedResult<TEntity>
                {
                    Items = items,
                    TotalItems = totalItems,
                    TotalPages = totalPages,
                    CurrentPage = pageIndex,
                    PageSize = pageSize
                });
            }

            return await query.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var item = await _dbSet.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity item)
        {
            _dbSet.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = item.GetType().GetProperty("Id").GetValue(item) }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity item)
        {
            if (id != (int)item.GetType().GetProperty("Id").GetValue(item))
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _dbSet.AnyAsync(e => (int)e.GetType().GetProperty("Id").GetValue(e) == id))
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
