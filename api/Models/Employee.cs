using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public int? PositionId { get; set; }

    public int? DepartmentId { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Employeetask> Employeetasks { get; set; } = new List<Employeetask>();

    public virtual Position? Position { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual ICollection<Worklog> Worklogs { get; set; } = new List<Worklog>();
}
