using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace api.Controllers
{
    public class ProjectsTechnologiesController : BaseController<Projecttechnology, MyDbContext>
    {
        public ProjectsTechnologiesController(MyDbContext context) : base(context)
        {
        }
        protected override Expression<Func<Projecttechnology, object>>[] Includes =>
        new Expression<Func<Projecttechnology, object>>[]
        {
            pt => pt.Project,
            pt => pt.Technology
        };

        protected override Expression<Func<Projecttechnology, object>> Projection =>
            pt => new
            {
                ID = pt.ID,
                ProjectFK = pt.ProjectId,
                TechnologyFK = pt.TechnologyId
            };

        protected override async Task<object> GetAdditionalDataAsync()
        {
            var ProjectFK = await _context.Projects.Select(p => new { p.ID, p.Name }).ToListAsync();
            var TechnologyFK = await _context.Technologies.Select(t => new { t.ID, t.Name }).ToListAsync();

            return new
            {
                ProjectFK,
                TechnologyFK
            };
        }
    }
}
