using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class ClientsFeedbacksController : BaseController<Clientfeedback, MyDbContext>
    {
        public ClientsFeedbacksController(MyDbContext context) : base(context)
        {
        }
    }
}
