using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class ProjectsDocumentsController : BaseController<Projectdocument, MyDbContext>
    {
        public ProjectsDocumentsController(MyDbContext context) : base(context)
        {
        }
    }
}
