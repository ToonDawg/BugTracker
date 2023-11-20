using BugTracker.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BugTracker.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.UserId);

        builder.Property(p => p.FirstName)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(p => p.LastName)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(p => p.Email)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasIndex(u => u.Email).IsUnique();
    }
}

