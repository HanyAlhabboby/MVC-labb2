using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockholmSchool5.Models;

namespace StockholmSchool5.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Classs> Classses { get; set; }
        public DbSet<StudentCourseTeacher> StudentCourseTeachers { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
