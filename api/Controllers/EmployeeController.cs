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
                PositionFK = e.Position != null ? e.PositionId : null,
                DepartmentFK = e.Department != null ? e.DepartmentId : null,
            };
        protected override async Task<object> GetAdditionalDataAsync()
        {
            var PositionFK = await _context.Positions.Select(p => new { p.ID, Name = p.Name }).ToListAsync();
            var DepartmentFK = await _context.Departments.Select(d => new { d.ID, d.Name }).ToListAsync();
            return new { PositionFK, DepartmentFK };
        }
    }
}
