using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Clientfeedback
{
    public int FeedbackId { get; set; }

    public int? ProjectId { get; set; }

    public int? ClientId { get; set; }

    public DateOnly? Date { get; set; }

    public string? Text { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Project? Project { get; set; }
}
