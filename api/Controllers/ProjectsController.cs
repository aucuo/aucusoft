using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class ProjectsController : BaseController<Project, MyDbContext>
    {
        public ProjectsController(MyDbContext context) : base(context)
        {
        }
    }
}
