using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Projecttechnology
{
    public int ProjectTechnologyId { get; set; }

    public int? ProjectId { get; set; }

    public int? TechnologyId { get; set; }

    public virtual Project? Project { get; set; }

    public virtual Technology? Technology { get; set; }
}
