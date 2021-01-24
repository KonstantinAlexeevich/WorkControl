using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WorkControl.Storage.Sqlite
{
    public static class StartupExtensions
    {
        public static IServiceCollection UseSqlite(this IServiceCollection services, string connection)
        {
            return services.AddDbContext<StorageContext>(options => options.UseSqlite(connection));
        }

        public static DbContextOptionsBuilder UseSqlite(this DbContextOptionsBuilder options, string connection)
        {
            return options.UseSqlite(connection,
                options => options.MigrationsAssembly(typeof(StartupExtensions).Assembly.GetName().Name));
        }
    }
}