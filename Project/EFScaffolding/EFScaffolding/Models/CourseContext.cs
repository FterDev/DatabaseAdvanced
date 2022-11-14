using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFScaffolding.Models;

public partial class CourseContext : DbContext
{
    public CourseContext()
    {
    }

    public CourseContext(DbContextOptions<CourseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=HELGADEV404\\MSSQLZBW01;Database=EFCoreDemo;Trusted_Connection=True;Encrypt=false;MultipleActiveResultSets=True;")
        .UseLazyLoadingProxies();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.Salary).HasColumnType("decimal(7, 2)");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasIndex(e => e.AuthorId, "IX_Courses_AuthorId");

            entity.HasIndex(e => e.CategoryId, "IX_Courses_CategoryId");

            entity.Property(e => e.FullPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Author).WithMany(p => p.Courses).HasForeignKey(d => d.AuthorId);

            entity.HasOne(d => d.Category).WithMany(p => p.Courses).HasForeignKey(d => d.CategoryId);

            entity.HasMany(d => d.Tags).WithMany(p => p.Courses)
                .UsingEntity<Dictionary<string, object>>(
                    "CourseTag",
                    r => r.HasOne<Tag>().WithMany().HasForeignKey("TagId"),
                    l => l.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
                    j =>
                    {
                        j.HasKey("CourseId", "TagId");
                        j.ToTable("CourseTag");
                        j.HasIndex(new[] { "TagId" }, "IX_CourseTag_TagId");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
