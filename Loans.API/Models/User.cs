using System;
using System.Collections.Generic;

namespace Loans.API.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PersonalData { get; set; } = null!;

    public virtual ICollection<Loan> LoanCreditors { get; set; } = new List<Loan>();

    public virtual ICollection<Loan> LoanDebtors { get; set; } = new List<Loan>();
}
