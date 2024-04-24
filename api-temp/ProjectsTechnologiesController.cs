using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class ProjectsTechnologiesController : BaseController<Projecttechnology, MyDbContext>
    {
        public ProjectsTechnologiesController(MyDbContext context) : base(context)
        {
        }
    }
}
