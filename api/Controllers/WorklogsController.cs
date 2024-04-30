using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace api.Controllers
{
    public class WorklogsController : BaseController<Worklog, MyDbContext>
    {
        public WorklogsController(MyDbContext context) : base(context)
        {
        }
        protected override Expression<Func<Worklog, object>>[] Includes =>
        new Expression<Func<Worklog, object>>[]
        {
        };
        protected override Expression<Func<Worklog, object>> Projection =>
            w => new
            {
                ID = w.ID,
                EmployeeFK = w.EmployeeId != null ? w.EmployeeId : null,
                ProjectFK = w.ProjectId,
                Time = w.HoursWorked,
                WorklogDate = w.Date
            };
        protected override async Task<object> GetAdditionalDataAsync()
        {
            var ProjectFK = await _context.Projects.Select(p => new { p.ID, p.Name }).ToListAsync();
            var EmployeeFK = await _context.Employees.Select(e => new { e.ID, e.Name }).ToListAsync();

            return new
            {
                ProjectFK,
                EmployeeFK
            };
        }
    }
}
