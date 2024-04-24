using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class PositionsController : BaseController<Position, MyDbContext>
    {
        public PositionsController(MyDbContext context) : base(context)
        {
        }
    }
}
