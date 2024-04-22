using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Projectdocument
{
    public int DocumentId { get; set; }

    public int? ProjectId { get; set; }

    public string Title { get; set; } = null!;

    public string? DocumentPath { get; set; }

    public DateOnly? CreationDate { get; set; }

    public virtual Project? Project { get; set; }
}
