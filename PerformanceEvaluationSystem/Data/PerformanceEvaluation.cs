using Microsoft.EntityFrameworkCore;

namespace PerformanceEvaluationSystem.Data
{
    public class PerformanceEvaluation : DbContext
    {
        public PerformanceEvaluation(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        { 
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Rating> Ratings { get; set; }
    }
}
