using EFTest.Models;

namespace EFTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoSave();
        }

        public static void DoSave()
        {
            using (var context = new CourseContext())
            {
                var author = new Author { Name = " Hans Muster", Salary = 4568 };
                var course = new Course { Title = "Test Course 21", Author = author, Description = "Test asdfasdf adasdfasf", FullPrice = 21500, Level = CourseLevel.Advanced};
                var category = new Category { Name = "Other Category" };
                course.Category = category;
                context.Courses.Add(course);
                context.SaveChanges();
            }
        }
    }
}