using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class TaskstatusesController : BaseController<Taskstatus, MyDbContext>
    {
        public TaskstatusesController(MyDbContext context) : base(context)
        {
        }
    }
}
