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
                Project = m.Project.Name,
                m.Agenda,
                m.MeetingDate,
            };
        protected override async Task<object> GetAdditionalDataAsync()
        {
            var clients = await _context.Clients.Select(c => new { c.ID, c.Name }).ToListAsync();
            var managers = await _context.Managers.Select(m => new { m.ID, m.Name }).ToListAsync();
            return new { clients, managers };
        }
    }
}
