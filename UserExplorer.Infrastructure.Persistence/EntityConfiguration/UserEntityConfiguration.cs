using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserExplorer.Core.Domain.Entities;

namespace UserExplorer.Infrastructure.Persistence.EntityConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.ToTable("Users");

            builder.Property(u => u.Name).IsRequired().HasMaxLength(60);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Phone).HasMaxLength(20);
            builder.Property(u => u.Company).HasMaxLength(100);
            builder.Property(u => u.City).IsRequired().HasMaxLength(50);

            builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}
