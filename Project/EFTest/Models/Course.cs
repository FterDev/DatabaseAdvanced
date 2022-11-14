using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CourseLevel Level { get; set; }
        public decimal FullPrice { get; set; }
        public virtual Author Author { get; set; }
        public int AuthorId { get; set; }
        public Category? Category { get; set; }

        public virtual ICollection<CourseTag> CourseTags { get; set; }
    }
}
