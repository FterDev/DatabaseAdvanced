using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal Salary { get; set; }
       


        public virtual ICollection<Course> Courses { get; set; }
    }
}
