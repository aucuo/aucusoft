using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace api.Controllers
{
    public class ManagersController : BaseController<Manager, MyDbContext>
    {
        public ManagersController(MyDbContext context) : base(context) {}
        protected override Expression<Func<Manager, object>>[] Includes =>
        new Expression<Func<Manager, object>>[]
        {
            m => m.Departments,
        };
        protected override Expression<Func<Manager, object>> Projection =>
            m => new
            {
                ID = m.ManagerId,
                m.Name,
                m.Position,
                Department = m.Departments.Select(d => d.Name),
            };
    }
}
