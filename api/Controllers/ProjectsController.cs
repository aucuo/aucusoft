using api.Context;
using api.Controllers;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class ProjectsController : BaseController<Project, MyDbContext>
{
    public ProjectsController(MyDbContext context) : base(context) {}
    protected override Expression<Func<Project, object>>[] Includes =>
        new Expression<Func<Project, object>>[]
        {
            p => p.Client,
            p => p.Manager,
        };
    protected override Expression<Func<Project, object>> Projection =>
        p => new
        {
            ID = p.ID,
            p.Name,
            p.StartDate,
            p.EndDate,
            p.Budget,
            ClientFK = p.Client != null ? p.ClientId : null,
            ManagerFK = p.Manager != null ? p.ManagerId : null,
        };
    protected override async Task<object> GetAdditionalDataAsync()
    {
        var ClientFK = await _context.Clients.Select(c => new { c.ID, c.Name }).ToListAsync();
        var ManagerFK = await _context.Managers.Select(m => new { m.ID, m.Name }).ToListAsync();

        return new 
        { 
            ClientFK,
            ManagerFK 
        };
    }
}
