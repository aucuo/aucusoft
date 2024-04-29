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
                Manager = d.Manager.Name,
            };
        protected override async Task<object> GetAdditionalDataAsync()
        {
            var clients = await _context.Clients.Select(c => new { c.ID, c.Name }).ToListAsync();
            var managers = await _context.Managers.Select(m => new { m.ID, m.Name }).ToListAsync();
            return new { clients, managers };
        }
    }
}
