using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace api.Models;

public partial class Project
{
    public int ID { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal? Budget { get; set; }

    public int? ClientId { get; set; }

    public int? ManagerId { get; set; }

    public virtual Client? Client { get; set; }
    public virtual Employee? ProjectManager { get; set; }
    public virtual ICollection<Clientfeedback> Clientfeedbacks { get; set; } = new List<Clientfeedback>();

    public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();

    public virtual ICollection<Projectdocument> Projectdocuments { get; set; } = new List<Projectdocument>();

    public virtual ICollection<Projecttechnology> Projecttechnologies { get; set; } = new List<Projecttechnology>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual ICollection<Worklog> Worklogs { get; set; } = new List<Worklog>();
}
