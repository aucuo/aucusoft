using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Projectdocument
{
    public int ID { get; set; }

    public int? ProjectId { get; set; }

    public string Title { get; set; } = null!;

    public string? DocumentPath { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual Project? Project { get; set; }
}
