using Buying.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buying.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.UserName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.ToTable("User");
        }
    }
}