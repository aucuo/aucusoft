using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Client
{
    public int ID { get; set; }

    public string Name { get; set; } = null!;

    public string? Industry { get; set; }

    public string? ContactPerson { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Clientfeedback> Clientfeedbacks { get; set; } = new List<Clientfeedback>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
