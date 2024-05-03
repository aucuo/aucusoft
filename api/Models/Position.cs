using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Position
{
    public int ID { get; set; }

    public string Name { get; set; } = null!;

    public int SalaryGrade { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
