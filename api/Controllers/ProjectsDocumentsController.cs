using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace api.Controllers
{
    public class ProjectsDocumentsController : BaseController<Projectdocument, MyDbContext>
    {
        public ProjectsDocumentsController(MyDbContext context) : base(context)
        {
        }
        protected override Expression<Func<Projectdocument, object>>[] Includes =>
        new Expression<Func<Projectdocument, object>>[]
        {
            pt => pt.Project,
        };

        protected override Expression<Func<Projectdocument, object>> Projection =>
            pt => new
            {
                ID = pt.ID,
                ProjectFK = pt.ProjectId,
                pt.Title,
                pt.DocumentPath,
                pt.CreationDate,
            };

        protected override async Task<object> GetAdditionalDataAsync()
        {
            var ProjectFK = await _context.Projects.Select(p => new { p.ID, p.Name }).ToListAsync();

            return new
            {
                ProjectFK,
            };
        }
    }
}
