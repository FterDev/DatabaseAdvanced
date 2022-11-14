using System;
using System.Collections.Generic;

namespace EFScaffolding.Models;

public partial class Tag
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; } = new List<Course>();
}
