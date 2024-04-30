using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Manager
{
    public int ID { get; set; }

    public string? Name { get; set; }

    public string? Position { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
