using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace api.Controllers
{
    public class MeetingsController : BaseController<Meeting, MyDbContext>
    {
        public MeetingsController(MyDbContext context) : base(context) {}
        protected override Expression<Func<Meeting, object>>[] Includes =>
        new Expression<Func<Meeting, object>>[]
        {
            m => m.Project,
        };
        protected override Expression<Func<Meeting, object>> Projection =>
            m => new
            {
                ID = m.ID,
                ProjectFK = m.Project != null ? m.ProjectId : null,
                m.Agenda,
                m.MeetingDate,
            };
        protected override async Task<object> GetAdditionalDataAsync()
        {
            var ProjectFK = await _context.Projects.Select(p => new { p.ID, p.Name }).ToListAsync();
            return new { ProjectFK };
        }
    }
}
