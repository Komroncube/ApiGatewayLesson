using System;
using System.Collections.Generic;

namespace Employee.API.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public int? Status { get; set; }

    public int? Role { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifyDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
