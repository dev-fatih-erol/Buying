using Buying.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buying.Infrastructure.Persistence.Configurations
{
    public class InstructionChannelConfiguration : IEntityTypeConfiguration<InstructionChannel>
    {
        public void Configure(EntityTypeBuilder<InstructionChannel> builder)
        {
            builder.HasKey(p => new { p.InstructionId, p.ChannelId });

            builder.HasOne(p => p.Instruction)
                   .WithMany(p => p.InstructionChannels)
                   .HasForeignKey(p => p.InstructionId);

            builder.HasOne(p => p.Channel)
                   .WithMany(p => p.InstructionChannels)
                   .HasForeignKey(p => p.ChannelId);

            builder.ToTable("InstructionChannel");
        }
    }
}