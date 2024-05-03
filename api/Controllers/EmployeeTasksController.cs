using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace api.Controllers
{
    public class EmployeeTasksController : BaseController<Employeetask, MyDbContext>
    {
        public EmployeeTasksController(MyDbContext context) : base(context)
        {
        }
        protected override Expression<Func<Employeetask, object>>[] Includes =>
        new Expression<Func<Employeetask, object>>[]
        {
        };
        protected override Expression<Func<Employeetask, object>> Projection =>
            et => new
            {
                ID = et.ID,
                TaskFK = et.TaskId != null ? et.TaskId : null,
                EmployeeFK = et.EmployeeId != null ? et.EmployeeId : null,
                et.TimeSpent,
                TaskDate = et.Date
            };
        protected override async Task<object> GetAdditionalDataAsync()
        {
            var TaskFK = await _context.Tasks.Select(t => new { t.ID, Name = t.Name + ": " + t.Project.Name }).ToListAsync();
            var EmployeeFK = await _context.Employees.Select(e => new { e.ID, e.Name }).ToListAsync();

            return new
            {
                TaskFK,
                EmployeeFK
            };
        }
    }
}
