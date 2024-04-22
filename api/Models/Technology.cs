﻿using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Technology
{
    public int TechnologyId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Projecttechnology> Projecttechnologies { get; set; } = new List<Projecttechnology>();
}
