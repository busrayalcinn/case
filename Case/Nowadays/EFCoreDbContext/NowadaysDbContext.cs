using Microsoft.EntityFrameworkCore;
using Nowadays.Models;
using Nowadays.Models.ValueObject;

namespace Nowadays.EFCoreDbContext
{
    public class NowadaysDbContext : DbContext
    {
        public NowadaysDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectEmployee>()
                .HasOne(a => a.Employee)
                .WithMany(b => b.ProjectEmployees)
                .HasForeignKey(c => c.EmployeeId);
            modelBuilder.Entity<ProjectEmployee>()
                .HasOne(a => a.Project)
                .WithMany(b => b.ProjectEmployees)
                .HasForeignKey(c => c.ProjectId);

        }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Project> Projects { get; set; }

    }
}
