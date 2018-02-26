using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace SmartIt.Security.Cors
{
   public class Startup
   {
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddCors(options =>
         {
            options.AddPolicy("SmartIt",
                builder => builder.WithOrigins("http://localhost:57675"));
         });
         services.AddMvc(options =>
         {
            options.Filters.Add(new CorsAuthorizationFilterFactory("SmartIt"));
         });
      }

      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         //app.UseCors("SmartIt");
         app.UseMvcWithDefaultRoute();
      }
   }
}