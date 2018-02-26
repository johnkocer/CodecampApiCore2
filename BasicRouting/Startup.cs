using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BasicRouting
{
   public class Startup
   {
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddMvc();
      }

      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         app.UseMvc(routes =>
         {
            routes.MapRoute(
               name: "gotoOne",
               template: "one",
               defaults: new { controller = "Home", action = "ViewOne" });

            routes.MapRoute(
               name: "gotoTwo",
               template: "two/{id?}",
               defaults: new { controller = "Home", action = "ViewTwo" });

            routes.MapRoute(
               name: "default",
               template: "{controller=Home}/{action=index}/{id?}");
         });

         app.UseMvc(routes =>
         {
            // Route template with default values and optional parameters
            //routes.MapRoute(
            //   name: "gotoOne",
            //   template:"{controller=Home}/{action=ViewOne}/{id?}");

            // Route template with default value, parameter constrainst
            ////routes.MapRoute(
            ////   name: "gotoTwo",
            ////   template: "{controller}/{action}/{id?}");

            // Route template with no default values or parameters
            //routes.MapRoute(
            //   name: "default",
            //   template: "{controller}/{action}/{id?}");
         });
      }
   }
}