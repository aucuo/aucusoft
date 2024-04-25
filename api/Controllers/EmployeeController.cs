using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace api.Controllers
{
    public class EmployeeController : BaseController<Employee, MyDbContext>
    {
        public EmployeeController(MyDbContext context) : base(context) {}
        protected override Expression<Func<Employee, object>>[] Includes =>
        new Expression<Func<Employee, object>>[]
        {
            e => e.Position,
            e => e.Department,
        };
        protected override Expression<Func<Employee, object>> Projection =>
            e => new
            {
                ID = e.ID,
                e.Name,
                Position = e.Position.Title,
                Department = e.Department.Name,
            };
    }
}
