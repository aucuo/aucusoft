using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace api.Controllers
{
    public class PositionsController : BaseController<Position, MyDbContext>
    {
        public PositionsController(MyDbContext context) : base(context){}
        protected override Expression<Func<Position, object>>[] Includes =>
        new Expression<Func<Position, object>>[]
        {
        };
        protected override Expression<Func<Position, object>> Projection =>
            p => new
            {
                ID = p.ID,
                p.Title,
                p.SalaryGrade,
            };
    }
}
