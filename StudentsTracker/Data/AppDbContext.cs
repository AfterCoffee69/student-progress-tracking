using Microsoft.EntityFrameworkCore;
using StudentsTracker.Models;

namespace StudentsTracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Major> Majors { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Credit> Credits { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

    }
}
