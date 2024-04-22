using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class EmployeeController : BaseController<Employee, MyDbContext>
    {
        public EmployeeController(MyDbContext context) : base(context)
        {
        }
    }
}
