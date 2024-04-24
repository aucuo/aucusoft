using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class ManagersController : BaseController<Manager, MyDbContext>
    {
        public ManagersController(MyDbContext context) : base(context)
        {
        }
    }
}
