using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace api.Controllers
{
    public class TaskstatusesController : BaseController<Taskstatus, MyDbContext>
    {
        public TaskstatusesController(MyDbContext context) : base(context)
        {
        }
        protected override Expression<Func<Taskstatus, object>>[] Includes =>
        new Expression<Func<Taskstatus, object>>[]
        {
        };

        protected override Expression<Func<Taskstatus, object>> Projection =>
            pt => new
            {
                ID = pt.ID,
                pt.Name
            };

        protected override async Task<object> GetAdditionalDataAsync()
        {
            return new { };
        }
    }
}
