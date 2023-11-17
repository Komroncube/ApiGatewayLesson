using System;
using System.Collections.Generic;

namespace UserTasks.Models;

public partial class Usertask
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Tasktitle { get; set; }

    public string? Taskdescription { get; set; }

    public DateOnly? Duedate { get; set; }

    public int? Taskstatus { get; set; }

    public int? Taskpriority { get; set; }
}
