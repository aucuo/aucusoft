using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class WorklogsController : BaseController<Worklog, MyDbContext>
    {
        public WorklogsController(MyDbContext context) : base(context)
        {
        }
    }
}
