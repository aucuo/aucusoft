using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace api.Controllers
{
    public class ManagersController : BaseController<Manager, MyDbContext>
    {
        public ManagersController(MyDbContext context) : base(context) {}
        protected override Expression<Func<Manager, object>>[] Includes =>
        new Expression<Func<Manager, object>>[]
        {
            m => m.Departments,
        };
        protected override Expression<Func<Manager, object>> Projection =>
            m => new
            {
                ID = m.ID,
                m.Name,
                m.Position,
                Department = m.Departments.Select(d => d.Name),
            };
        protected override async Task<object> GetAdditionalDataAsync()
        {
            var clients = await _context.Clients.Select(c => new { c.ID, c.Name }).ToListAsync();
            var managers = await _context.Managers.Select(m => new { m.ID, m.Name }).ToListAsync();
            return new { clients, managers };
        }
    }
}
