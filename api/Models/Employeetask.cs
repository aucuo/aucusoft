using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Employeetask
{
    public int ID { get; set; }

    public int? TaskId { get; set; }

    public int? EmployeeId { get; set; }

    public int? TimeSpent { get; set; }

    public DateOnly? Date { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Task? Task { get; set; }
}
