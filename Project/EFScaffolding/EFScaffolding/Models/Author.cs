using System;
using System.Collections.Generic;

namespace EFScaffolding.Models;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? City { get; set; }

    public string? Phone { get; set; }

    public decimal Salary { get; set; }

    public virtual ICollection<Course> Courses { get; } = new List<Course>();
}
