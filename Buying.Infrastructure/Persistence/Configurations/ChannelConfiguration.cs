using Buying.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buying.Infrastructure.Persistence.Configurations
{
    public class ChannelConfiguration : IEntityTypeConfiguration<Channel>
    {
        public void Configure(EntityTypeBuilder<Channel> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Type)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.ToTable("Channel");
        }
    }
}