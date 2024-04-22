using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class MeetingsController : BaseController<Meeting, MyDbContext>
    {
        public MeetingsController(MyDbContext context) : base(context)
        {
        }
    }
}
