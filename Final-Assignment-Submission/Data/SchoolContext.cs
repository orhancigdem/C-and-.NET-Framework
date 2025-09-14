using System;
using CodeFirstDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstDemo.Data
{
    public class SchoolContext : DbContext
    {
        private string _databaseName;

        public SchoolContext(string studentName = "Default") : base()
        {
            _databaseName = $"SchoolDB_{studentName.Replace(" ", "_")}";
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server=(localdb)\mssqllocaldb;Database={_databaseName};Trusted_Connection=True;");
        }
    }
} 