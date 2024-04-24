using api.Context;
using api.Controllers;
using api.Models;
using System.Linq.Expressions;

public class ProjectsController : BaseController<Project, MyDbContext>
{
    public ProjectsController(MyDbContext context) : base(context) {}
    protected override Expression<Func<Project, object>>[] Includes =>
        new Expression<Func<Project, object>>[]
        {
            p => p.Client,
            p => p.ProjectManager,
        };
    protected override Expression<Func<Project, object>> Projection =>
        p => new
        {
            ID = p.ProjectId,
            p.Name,
            p.StartDate,
            p.EndDate,
            p.Budget,
            Client = p.Client.Name,
            Manager = p.ProjectManager.Name,
        };
}
