using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Loans.API.Models;

public partial class UserLoansContext : DbContext
{
    public UserLoansContext()
    {
    }

    public UserLoansContext(DbContextOptions<UserLoansContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasIndex(e => e.CreditorsId, "IX_Loans_CreditorsId");

            entity.HasIndex(e => e.DebtorsId, "IX_Loans_DebtorsId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Creditors).WithMany(p => p.LoanCreditors).HasForeignKey(d => d.CreditorsId);

            entity.HasOne(d => d.Debtors).WithMany(p => p.LoanDebtors).HasForeignKey(d => d.DebtorsId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

    }

}
