using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Task
{
    public int ID { get; set; }

    public int? ProjectId { get; set; }

    public int? AssignedTo { get; set; }

    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? StatusId { get; set; }

    public virtual Employee? AssignedToNavigation { get; set; }

    public virtual ICollection<Employeetask> Employeetasks { get; set; } = new List<Employeetask>();

    public virtual Project? Project { get; set; }

    public virtual Taskstatus? Status { get; set; }
}
