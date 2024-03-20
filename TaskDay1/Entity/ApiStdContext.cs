using Microsoft.EntityFrameworkCore;
using TaskDay1.Model;

namespace TaskDay1.Entity
{
    public class ApiStdContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Depertment> Depertments { get; set; }
        public DbSet<Course>Courses { get; set; }

        public DbSet<StudentCourse> studentCourses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-FH5NNMR;Database=ApiDay1;Encrypt=false;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
