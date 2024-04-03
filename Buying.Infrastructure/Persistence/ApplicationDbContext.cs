using Buying.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buying.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Instruction> Instructions { get; set; }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<InstructionChannel> InstructionChannels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}