using BugTracker.Domain.Users.Entities;
using BugTracker.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Infrastructure.Data.Context;
public class BugTrackerDbContext : DbContext
{
    public BugTrackerDbContext(DbContextOptions<BugTrackerDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfiguration());

    }

}