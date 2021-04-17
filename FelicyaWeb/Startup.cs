using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using FelicyaDB;

namespace FelicyaClient
{
  public class Startup
  {
    public IConfiguration Configuration { get; }
    public IWebHostEnvironment Environment { get; }

    private string DatabaseConnectionString { get; }

    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
      //TODO: Fint til test
      Configuration = configuration;
      Environment = environment;

      // DatabaseConnectionString = new MySqlConnectionStringBuilder(Configuration.GetConnectionString("DefaultConnection"))
         // .TranslateSrvServer()
          //.ConnectionString;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    #region ConfigureServices
    public void ConfigureServices(IServiceCollection services)
    {
      // Add framework services.
      services.AddMvc();

      services.AddDbContext<FelicyaContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      //services.AddRfHealthChecks();

      // services.AddSingleton<BundleHelper>();
      //services.AddScoped<EventManager>();

      /*if (Environment.IsDevelopment())
      {
        // Hangfire does not run before a hosted service is run, so it doesn't configure properly.
        // TODO: Figure out how to seed the DB & not do this ..
        JobStorage.Current = new MemoryStorage();

        services.AddDbContext<FelicyaContext>(builder => builder
                .UseInMemoryDatabase("rf-rekrut"))
            .UseAfterSaveChanges<AfterSaveChangesService>()
            .AddScoped<IDatabaseSeeder, RfContextSeeder>();

        services.AddHangfire(configuration => configuration
            .UseMemoryStorage());
      }
      else
      {
        services.AddDbContext<FelicyaContext>(builder => builder.UseMySql(DatabaseConnectionString, DbConstants.ServerVersion))
            .UseAfterSaveChanges<AfterSaveChangesService>()
            .AddScoped<RfContextNoTracking>();

        services.AddHangfire(configuration => configuration.UseStorage(new MySqlStorage(DatabaseConnectionString, new MySqlStorageOptions())));
      }

      services
          .Configure<AutoProxyOptions>(Configuration.GetSection("ProxySupport"))
          .AddAutoProxyMiddleware();

      services.AddMemoryCache();
      services.AddScoped<ConfigurationManager>();

      services.AddScoped<AutoMarkService>();
      services.Configure<GDPROptions>(Configuration.GetSection("GDPR"));

      */
      services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(10));
    }
    #endregion


    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
     // app.UseAutoProxyMiddleware();
     // app.UseHealthChecks("/health");
      //app.UseRfHealthchecks();
      
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseBrowserLink();
        app.UseStatusCodePages();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }


      app.UseRouting();
      app.UseCors();
      app.UseSession();

      app.UseStaticFiles();


      //app.UseRewriter(new RewriteOptions()
      //  .Add(new RedirectDisabledSite(Assembly.GetEntryAssembly().GetName().Name, "ClosedDown")));

      //TODO: ClosedDown?
      app.UseEndpoints(
             endpoints =>
             {
               endpoints.MapControllerRoute("closedDown", "ClosedDown/{action=Index}", new { controller = "ClosedDown" });
               endpoints.MapControllerRoute("default", "{controller=Projects}/{action=Welcome}/{id?}");
             });

      /*app.UseMvc(routes =>
      {
        routes.MapRoute(
            name: "closedDown",
            template: "ClosedDown/{action=Index}",
            defaults: new { controller = "ClosedDown" });
        routes.MapRoute(
            name: "default",
            template: "{controller=Projects}/{action=Index}/{id?}");
      });*/

     /* // Setup hangfire. Note: This is a complete hack to ensure we can use the hangfire client
      app.UseHangfireServer(new BackgroundJobServerOptions
      {
        Queues = new[] { "DUMMY_QUEUE" },
        WorkerCount = 1,
        ServerName = typeof(Startup).Assembly.GetName().Name
      });*/
    }
  }
}
