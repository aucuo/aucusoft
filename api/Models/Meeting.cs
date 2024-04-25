using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Meeting
{
    public int ID { get; set; }

    public int? ProjectId { get; set; }

    public DateOnly? MeetingDate { get; set; }

    public string? Agenda { get; set; }

    public virtual Project? Project { get; set; }
}
