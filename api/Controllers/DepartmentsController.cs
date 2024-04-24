using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace api.Controllers
{
    public class DepartmentsController : BaseController<Department, MyDbContext>
    {
        public DepartmentsController(MyDbContext context) : base(context) {}
        protected override Expression<Func<Department, object>>[] Includes =>
        new Expression<Func<Department, object>>[]
        {
            d => d.Manager,
        };
        protected override Expression<Func<Department, object>> Projection =>
            d => new
            {
                ID = d.DepartmentId,
                d.Name,
                Manager = d.Manager.Name,
            };
    }
}
