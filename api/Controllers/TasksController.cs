using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace api.Controllers
{
    public class TasksController : BaseController<Models.Task, MyDbContext>
    {
        public TasksController(MyDbContext context) : base(context)
        {
        }
        protected override Expression<Func<Models.Task, object>>[] Includes =>
        new Expression<Func<Models.Task, object>>[]
        {
        };

        protected override Expression<Func<Models.Task, object>> Projection =>
            pt => new
            {
                ID = pt.ID,
                ProjectFK = pt.ProjectId,
                pt.Description,
                pt.StartDate,
                pt.EndDate,
                StatusFK = pt.StatusId,
            };

        protected override async Task<object> GetAdditionalDataAsync()
        {
            var ProjectFK = await _context.Projects.Select(p => new { p.ID, p.Name }).ToListAsync();
            var StatusFK = await _context.Taskstatuses.Select(s => new { s.ID, s.Name }).ToListAsync();
            return new { ProjectFK, StatusFK };
        }
    }
}
