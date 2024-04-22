using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class TasksController : BaseController<api.Models.Task, MyDbContext>
    {
        public TasksController(MyDbContext context) : base(context)
        {
        }
    }
}
