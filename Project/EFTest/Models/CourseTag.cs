using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest.Models
{
    public class CourseTag
    {
        public virtual Course Course { get; set; }
        public virtual Tag Tag { get; set; }

        public int CourseId { get; set; }
        public int TagId { get; set; }


    }
}
