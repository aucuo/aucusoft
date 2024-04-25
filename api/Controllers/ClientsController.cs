using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
