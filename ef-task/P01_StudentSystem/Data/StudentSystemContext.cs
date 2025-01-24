using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data
{
    internal class StudentSystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EFTest511;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .Property(e => e.Name)
                .HasMaxLength(100);
            modelBuilder.Entity<Student>()
                .Property(e => e.PhoneNumber)
                .HasColumnType("varchar(10)")
                .IsRequired(false);


            modelBuilder.Entity<Course>()
                .Property(e => e.Name)
                .HasMaxLength(80);
            modelBuilder.Entity<Course>()
                .Property(e => e.Description)
                .IsRequired(false);


            modelBuilder.Entity<Resource>()
                .Property(e => e.Name)
                .HasMaxLength(50);
            modelBuilder.Entity<Resource>()
                .Property(e => e.Url)
                .IsUnicode(false);
            modelBuilder.Entity<Resource>()
                .HasOne(e => e.Course)
                .WithMany(e => e.Resources)
                .HasForeignKey(e => e.CourseId);


            modelBuilder.Entity<Homework>()
                .Property(e => e.Content)
                .IsUnicode (false);
            modelBuilder.Entity<Homework>()
                .HasOne(e => e.Student)
                .WithMany(e => e.HomeworkSubmissions)
                .HasForeignKey (e => e.StudentId);
            modelBuilder.Entity<Homework>()
                .HasOne(e => e.Course)
                .WithMany(e => e.HomeworkSubmissions)
                .HasForeignKey(e => e.CourseId);


            modelBuilder.Entity<StudentCourse>()
                .HasKey(e => new {e.StudentId, e.CourseId});
            modelBuilder.Entity<StudentCourse>()
                .HasOne(e => e.Student)
                .WithMany(e => e.StudentCourses)
                .HasForeignKey(e => e.StudentId);
            modelBuilder.Entity<StudentCourse>()
                .HasOne(e => e.Course)
                .WithMany (e => e.StudentCourses)
                .HasForeignKey(e => e.CourseId);
        }
    }
}
