using api.Context;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace api.Controllers
{
    public class MeetingsController : BaseController<Meeting, MyDbContext>
    {
        public MeetingsController(MyDbContext context) : base(context) {}
        protected override Expression<Func<Meeting, object>>[] Includes =>
        new Expression<Func<Meeting, object>>[]
        {
            m => m.Project,
        };
        protected override Expression<Func<Meeting, object>> Projection =>
            m => new
            {
                ID = m.ID,
                Project = m.Project.Name,
                m.Agenda,
                m.MeetingDate,
            };
    }
}
