using System;
using System.Collections.Generic;

namespace UserTasks.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public DateOnly? Birthdate { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }
}
