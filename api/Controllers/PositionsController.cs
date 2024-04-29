using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace api.Controllers
{
    public class PositionsController : BaseController<Position, MyDbContext>
    {
        public PositionsController(MyDbContext context) : base(context){}
        protected override Expression<Func<Position, object>>[] Includes =>
        new Expression<Func<Position, object>>[]
        {
        };
        protected override Expression<Func<Position, object>> Projection =>
            p => new
            {
                ID = p.ID,
                p.Title,
                p.SalaryGrade,
            };
        protected override async Task<object> GetAdditionalDataAsync()
        {
            var clients = await _context.Clients.Select(c => new { c.ID, c.Name }).ToListAsync();
            var managers = await _context.Managers.Select(m => new { m.ID, m.Name }).ToListAsync();
            return new { clients, managers };
        }
    }
}
