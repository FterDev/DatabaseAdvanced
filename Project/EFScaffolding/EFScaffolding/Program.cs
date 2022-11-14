
using EFScaffolding.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace EFScaffolding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using( var context = new CourseContext())
            {
                context.Database.Migrate();
            }


            DoQuery();
        }

        public static void DoQuery()
        {
            using(var context = new CourseContext())
            {


                /*/ lazy loading
                var authorQuery = context.Authors.Single(x => x.Id == 2);

                foreach(var course in authorQuery.Courses)
                {
                    Console.WriteLine($"Kurstitel: {course.Title} -  Author: {course.Author.Name}");
                }
                end lazy loading*/
                
                var query = from c in context.Courses where c.Title.Contains("test") orderby c.Title select c;
                
                foreach(var course in query.Include(x => x.Author))
                {  
                    Console.WriteLine($"Kurstitel: {course.Title} -  Author: { course.Author.Name }");
                }

                //two ways to get author
                /**
                 * Lazy loading
                 * 
                 * Eager loading
                 * 
                 * 
                 */

                /*var courses = context.Courses.Where(c => c.Title.Contains("test")).OrderBy(c => c.Title);

                foreach (var course in courses)
                {
                    Console.WriteLine(course.Title);
                }*/

            }



            
        }
    }
}