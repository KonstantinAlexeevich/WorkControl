using System;
using EventFlow.AspNetCore.Extensions;
using EventFlow.DependencyInjection.Extensions;
using EventFlow.Extensions;
using EventFlow.PostgreSql;
using EventFlow.PostgreSql.Connections;
using EventFlow.PostgreSql.EventStores;
using EventFlow.PostgreSql.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkControl.Blazor.ServerSide.Areas.Identity;
using WorkControl.Blazor.ServerSide.Data;
using WorkControl.Domain.Work.Commands;
using WorkControl.Domain.Work.Events;
using WorkControl.Storage;
using WorkControl.Storage.PostgreSql;

namespace WorkControl.Blazor.ServerSide
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.UseNpgsql(Configuration.GetConnectionString("NpgSqlConnection"));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<StorageContext>();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services
                .AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>
                >();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddSingleton<WeatherForecastService>();

            services.AddEventFlow(ef =>
            {
                ef.AddDefaults(typeof(Startup).Assembly)
                    //.AddAspNetCoreMetadataProviders()
                    .AddAspNetCore(x => x.AddDefaultMetadataProviders())
                    .ConfigurePostgreSql(
                        PostgreSqlConfiguration.New.SetConnectionString(
                            Configuration.GetConnectionString("NpgSqlConnection")))
                    .AddEvents(typeof(RenameEvent))
                    .AddCommands(typeof(RenameCommand))
                    .AddCommandHandlers(typeof(RenameCommandHandler))
                    .UseConsoleLog()
                    .UsePostgreSqlEventStore();
            });
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();
            using var context = serviceScope.ServiceProvider.GetRequiredService<StorageContext>();
            context.Database.Migrate();

            var msSqlDatabaseMigrator = serviceProvider.GetRequiredService<IPostgreSqlDatabaseMigrator>();
            EventFlowEventStoresPostgreSql.MigrateDatabase(msSqlDatabaseMigrator);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider sp)
        {
            UpdateDatabase(sp);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}