using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class TechnologiesController : BaseController<Technology, MyDbContext>
    {
        public TechnologiesController(MyDbContext context) : base(context)
        {
        }
    }
}
