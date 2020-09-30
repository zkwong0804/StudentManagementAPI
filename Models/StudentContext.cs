using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace StudentManagementAPI.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<Faculty> Faculties {get;set;}
        public DbSet<Course> Courses {get;set;}
        public DbSet<Student> Students {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder opt)
        {
            try
            {
                string connString = $"{Directory.GetCurrentDirectory()}/StudentAPI.db";
                opt.UseSqlite($"Data Source={connString}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to connect sqlite db [{ex.Message}]");
            }
        }
    }
}