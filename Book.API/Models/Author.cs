using System;
using System.Collections.Generic;

namespace Book.API.Models;

public partial class Author
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public decimal Salary { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
