using Demo2.Modals;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2.Data
{
    internal class ITIContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;database=ITIEFDB;Integrated Security=True;Trust Server Certificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Flunet API // Have Higher Pirority rather than by convention By Data Annotation
            // Using Also When you have the IL of the
            // Class and You want to change something so you can use Flunet A{I

            /// modelBuilder.Entity<Department>(b =>
            /// {
            ///     b.HasKey(s => s.Id);
            ///     b.Property(s => s.DeptName).IsRequired();
            ///     b.Property(s => s.DeptName).HasMaxLength(20);
            /// });

            /// modelBuilder.Entity<Student>(std =>
            /// {
            ///     std.HasKey(s => s.StdId);
            ///     std.Property(s => s.StdId).ValueGeneratedNever();
            ///     //std.Property(s=>s.Name).HasColumnName("Student Name");
            ///     std.Property(s => s.Name).HasMaxLength(20).IsRequired();
            ///     std.Property(s => s.Age).IsRequired(false);
            /// });

            modelBuilder.Entity<Course>(c =>
            {
                c.HasKey(c => c.CrsId);
                c.Property(c => c.CrsId).ValueGeneratedNever();
                c.Property(c => c.CrsName).IsRequired().HasMaxLength(20);
                
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
