using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace api.Controllers
{
    public class EmployeeController : BaseController<Employee, MyDbContext>
    {
        public EmployeeController(MyDbContext context) : base(context) {}
        protected override Expression<Func<Employee, object>>[] Includes =>
        new Expression<Func<Employee, object>>[]
        {
            e => e.Position,
            e => e.Department,
        };
        protected override Expression<Func<Employee, object>> Projection =>
            e => new
            {
                ID = e.ID,
                e.Name,
                Position = e.Position.Title,
                Department = e.Department.Name,
            };
        protected override async Task<object> GetAdditionalDataAsync()
        {
            var clients = await _context.Clients.Select(c => new { c.ID, c.Name }).ToListAsync();
            var managers = await _context.Managers.Select(m => new { m.ID, m.Name }).ToListAsync();
            return new { clients, managers };
        }
    }
}
