using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WorkControl.Storage.PostgreSql
{
    public static class StartupExtensions
    {
        public static IServiceCollection UseNpgsql(this IServiceCollection services, string connection)
        {
            return services.AddDbContext<StorageContext>(options => options.UseNpgsql(connection));
        }

        public static DbContextOptionsBuilder UseNpgsql(this DbContextOptionsBuilder options, string connection)
        {
            return options.UseNpgsql(connection,
                options => options.MigrationsAssembly(typeof(StartupExtensions).Assembly.GetName().Name));
        }
    }
}