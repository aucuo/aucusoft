using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class EmployeeTasksController : BaseController<Employeetask, MyDbContext>
    {
        public EmployeeTasksController(MyDbContext context) : base(context)
        {
        }
    }
}
