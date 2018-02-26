using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;

namespace SmartIt.Security.RequireHttps
{
   public class Startup
   {
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddMvc(options =>
         {
            // HTTPS for IIS Express, you can enable SSL from project Properties > Debug tab by checking the Enable SSL flag.
            options.Filters.Add(new RequireHttpsAttribute());
         });
      }

      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         var options = new RewriteOptions().AddRedirectToHttps(StatusCodes.Status301MovedPermanently, 44377);

         app.UseRewriter(options);
         app.UseMvcWithDefaultRoute();
      }
   }
}