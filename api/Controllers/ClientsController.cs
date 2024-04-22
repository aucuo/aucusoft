using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class ClientsController : BaseController<Client, MyDbContext>
    {
        public ClientsController(MyDbContext context) : base(context)
        {
        }
    }
}
