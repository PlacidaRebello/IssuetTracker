using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<IssueType> IssueType { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<SprintStatus> SprintStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
