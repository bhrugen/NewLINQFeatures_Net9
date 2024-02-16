using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewLINQFeatures.Models;

namespace NewLINQFeatures.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentScore> StudentScores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>().HasData(
               new Student { Id = 1, Name = "Ben", Gender = "Male" },
               new Student { Id = 2, Name = "Bill", Gender = "Male" },
               new Student { Id = 3, Name = "Lana", Gender = "Female" }
           );

            builder.Entity<StudentScore>().HasData(
               new StudentScore { Id = 1, StudentId = 1, Score = 99, SubjectName = "Math" },
               new StudentScore { Id = 2, StudentId = 1, Score = 85, SubjectName = "Science" },
               new StudentScore { Id = 3, StudentId = 1, Score = 85, SubjectName = "Geography" },

               new StudentScore { Id = 4, StudentId = 2, Score = 65, SubjectName = "Math" },
               new StudentScore { Id = 5, StudentId = 2, Score = 59, SubjectName = "Science" },
               new StudentScore { Id = 6, StudentId = 2, Score = 80, SubjectName = "Geography" },

               new StudentScore { Id = 7, StudentId = 3, Score = 50, SubjectName = "Math" },
               new StudentScore { Id = 8, StudentId = 3, Score = 70, SubjectName = "Science" },
               new StudentScore { Id = 9, StudentId = 3, Score = 90, SubjectName = "Geography" }
           );

        }
    }
}
