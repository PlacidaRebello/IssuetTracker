﻿using DataAccess.DataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueStatus> IssueStatus { get; set; }
        public DbSet<IssueType> IssueType { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<SprintStatus> SprintStatuses { get; set; }
        public DbSet<Release> Release { get; set; }
        public DbSet<IssueDetails> IssueDetails { get; set; }
        public DbSet<IssuePriority> IssuePriority { get; set; }
        public DbSet<DailyBurnDown> DailyBurnDown { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Release>()
                         .HasMany<Sprint>(s => s.Sprints)
                         .WithOne(x=>x.Release)
                         .HasForeignKey(r=>r.ReleaseId)
                         .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
