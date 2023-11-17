using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CategoryBookMVC.Models;

public partial class BulkyBooksMvcContext : DbContext
{
    public BulkyBooksMvcContext()
    {
    }

    public BulkyBooksMvcContext(DbContextOptions<BulkyBooksMvcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

}
