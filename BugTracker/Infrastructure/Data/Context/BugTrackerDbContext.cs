using BugTracker.Domain.Common.Entities;
using BugTracker.Domain.Users.Entities;
using BugTracker.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Infrastructure.Data.Context;


public class BugTrackerDbContext(DbContextOptions<BugTrackerDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfiguration());


    }

    public override int SaveChanges()
    {
        UpdateAuditEntries();
        return base.SaveChanges();
    }

    private void UpdateAuditEntries()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
    }
}