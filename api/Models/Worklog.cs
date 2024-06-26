﻿using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Worklog
{
    public int ID { get; set; }

    public int? EmployeeId { get; set; }

    public int? ProjectId { get; set; }

    public int? HoursWorked { get; set; }

    public DateTime? Date { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Project? Project { get; set; }
}
