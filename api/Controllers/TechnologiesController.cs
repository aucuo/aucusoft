using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace api.Controllers
{
    public class TechnologiesController : BaseController<Technology, MyDbContext>
    {
        public TechnologiesController(MyDbContext context) : base(context)
        {
        }

        protected override Expression<Func<Technology, object>>[] Includes =>
            new Expression<Func<Technology, object>>[]
            {
            };

        protected override Expression<Func<Technology, object>> Projection =>
            t => new
            {
                ID = t.ID,
                t.Name,
                t.Description
            };

        protected override async Task<object> GetAdditionalDataAsync()
        {
            return new { };
        }
    }
}
