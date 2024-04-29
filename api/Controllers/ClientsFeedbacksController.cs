using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace api.Controllers
{
    public class ClientsFeedbacksController : BaseController<Clientfeedback, MyDbContext>
    {
        public ClientsFeedbacksController(MyDbContext context) : base(context) {}
        protected override Expression<Func<Clientfeedback, object>>[] Includes =>
        new Expression<Func<Clientfeedback, object>>[]
        {
            cf => cf.Project,
            cf => cf.Client,
        };
        protected override Expression<Func<Clientfeedback, object>> Projection =>
            cf => new
            {
                ID = cf.ID,
                Project = cf.Project.Name,
                cf.Text,
                cf.Date,
            };
        protected override async Task<object> GetAdditionalDataAsync()
        {
            var clients = await _context.Clients.Select(c => new { c.ID, c.Name }).ToListAsync();
            var managers = await _context.Managers.Select(m => new { m.ID, m.Name }).ToListAsync();
            return new { clients, managers };
        }
    }
}
