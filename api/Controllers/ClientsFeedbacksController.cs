using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace api.Controllers
{
    public class ClientsFeedbacksController : BaseController<Clientfeedback, MyDbContext>
    {
        public ClientsFeedbacksController(MyDbContext context) : base(context) {}
        protected override Expression<Func<Clientfeedback, object>>[] Includes =>
        new Expression<Func<Clientfeedback, object>>[]
        {
            cf => cf.Project,
            cf => cf.Client,
        };
        protected override Expression<Func<Clientfeedback, object>> Projection =>
            cf => new
            {
                ID = cf.ID,
                Project = cf.Project.Name,
                cf.Text,
                cf.Date,
            };
    }
}
