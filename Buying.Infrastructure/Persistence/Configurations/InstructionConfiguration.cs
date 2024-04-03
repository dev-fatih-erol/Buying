using Buying.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buying.Infrastructure.Persistence.Configurations
{
    public class InstructionConfiguration : IEntityTypeConfiguration<Instruction>
    {
        public void Configure(EntityTypeBuilder<Instruction> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Amount)
                   .IsRequired()
                   .HasColumnType("decimal(18,4)");

            builder.Property(p => p.ExecutionDay)
                   .IsRequired();

            builder.Property(p => p.InstructionStatus)
                   .IsRequired()
                   .HasConversion<int>();

            builder.HasOne(p => p.User)
                   .WithMany(p => p.Instructions)
                   .HasForeignKey(p => p.UserId);

            builder.ToTable("Instruction");
        }
    }
}