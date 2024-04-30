using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace api.Controllers
{
    public class DepartmentsController : BaseController<Department, MyDbContext>
    {
        public DepartmentsController(MyDbContext context) : base(context) {}
        protected override Expression<Func<Department, object>>[] Includes =>
        new Expression<Func<Department, object>>[]
        {
            d => d.Manager,
        };
        protected override Expression<Func<Department, object>> Projection =>
            d => new
            {
                ID = d.ID,
                d.Name,
                ManagerFK = d.Manager != null ? d.ManagerId : null,
            };
        protected override async Task<object> GetAdditionalDataAsync()
        {
            var ManagerFK = await _context.Managers.Select(m => new { m.ID, m.Name }).ToListAsync();
            return new { ManagerFK };
        }
    }
}
