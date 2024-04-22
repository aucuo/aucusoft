using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class DepartmentsController : BaseController<Department, MyDbContext>
    {
        public DepartmentsController(MyDbContext context) : base(context)
        {
        }
    }
}
