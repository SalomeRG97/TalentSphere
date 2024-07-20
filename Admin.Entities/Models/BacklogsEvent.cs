using System;
using System.Collections.Generic;

namespace Admin.Entities.Models;

public partial class BacklogsEvent
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public int EventType { get; set; }

    public string Json { get; set; }
}
