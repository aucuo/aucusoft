using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Taskstatus
{
    public int StatusId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
