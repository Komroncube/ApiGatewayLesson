using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UserTasks.Models;

public partial class ToDoAppContext : DbContext
{
    public ToDoAppContext()
    {
    }

    public ToDoAppContext(DbContextOptions<ToDoAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Usertask> Usertasks { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pkey");

            entity.ToTable("user");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("lastname");
            entity.Property(e => e.Password)
                .HasMaxLength(8)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Usertask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Usertasks_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Duedate).HasColumnName("duedate");
            entity.Property(e => e.Taskdescription)
                .HasColumnType("character varying")
                .HasColumnName("taskdescription");
            entity.Property(e => e.Taskpriority).HasColumnName("taskpriority");
            entity.Property(e => e.Taskstatus).HasColumnName("taskstatus");
            entity.Property(e => e.Tasktitle)
                .HasColumnType("character varying")
                .HasColumnName("tasktitle");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

    }

}
