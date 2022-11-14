using EFTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest
{
    public class CourseContext : DbContext
    {
        public  DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=HELGADEV404\\MSSQLZBW01;Database=EFCoreDemo;Trusted_Connection=True;");

            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Debug);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseTag>().HasKey(t => new { t.CourseId, t.TagId });

            //Foreign Keys n:n 
            modelBuilder.Entity<CourseTag>()
                .HasOne(ct => ct.Course)
                .WithMany(c => c.CourseTags)
                .HasForeignKey(ct => ct.CourseId);

            //Erstellung einer 1:n-Verbindung zwischen  zwischen Tag und CourseTag
            // Entity CourseTag hat ein Tag(HasOne)
            // welches auf die Liste Tag.Course verweist(WithMany)
            // Für die Speicherung des FK soll das Attribut TagId verwendet werden (HasForeignKey)
            modelBuilder.Entity<CourseTag>()
                .HasOne(ct => ct.Tag)
                .WithMany(c => c.CourseTags)
                .HasForeignKey(ct => ct.TagId);

            modelBuilder.Entity<Author>().HasData(new Author { Id = 10, Name = "Other Test", City = "SG", Phone = "123213", Salary = 5000 });
            modelBuilder.Entity<Author>().HasData(new Author { Id = 10, Name = "Other Test 2", City = "SG", Phone = "123213", Salary = 5000 });
        }
    }
}
