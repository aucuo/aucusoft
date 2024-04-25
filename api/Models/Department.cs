using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Department
{
    public int ID { get; set; }

    public string Name { get; set; } = null!;

    public int? ManagerId { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Manager? Manager { get; set; }
}
