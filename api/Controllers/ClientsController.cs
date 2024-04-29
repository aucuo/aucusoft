using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace api.Controllers
{
    public class ClientsController : BaseController<Client, MyDbContext>
    {
        public ClientsController(MyDbContext context) : base(context) {}
        protected override Expression<Func<Client, object>>[] Includes =>
        new Expression<Func<Client, object>>[]
        {
        };
        protected override Expression<Func<Client, object>> Projection =>
            c => new
            {
                ID = c.ID,
                c.Name,
                c.Industry,
                c.ContactPerson,
                c.Email,
                c.Phone,
            };
        protected override async Task<object> GetAdditionalDataAsync()
        {
            var clients = await _context.Clients.Select(c => new { c.ID, c.Name }).ToListAsync();
            var managers = await _context.Managers.Select(m => new { m.ID, m.Name }).ToListAsync();
            return new { clients, managers };
        }
    }
}
