using Buying.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Buying.Infrastructure.Common.Extensions
{
    public static class ServiceCollectionExtensions
	{
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(
                        configuration.GetConnectionString("DefaultConnection"),
                        o => o.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return services;
        }
    }
}