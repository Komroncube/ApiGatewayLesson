using System;
using System.Collections.Generic;

namespace Loans.API.Models;

public partial class Loan
{
    public Guid Id { get; set; }

    public Guid DebtorId { get; set; }

    public Guid DebtorsId { get; set; }

    public Guid CreditorId { get; set; }

    public double Money { get; set; }

    public DateTime TakeDate { get; set; }

    public DateTime ReturnDate { get; set; }

    public Guid CreditorsId { get; set; }

    public virtual User Creditors { get; set; } = null!;

    public virtual User Debtors { get; set; } = null!;
}
