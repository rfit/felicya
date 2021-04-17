using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
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

      services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(10));
    }
    #endregion

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
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

    }
  }
}
