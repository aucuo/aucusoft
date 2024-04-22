using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Manager
{
    public int ManagerId { get; set; }

    public string? Name { get; set; }

    public string? Position { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
