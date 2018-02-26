using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace SaAuthentication
{
   public class Startup
   {
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddAuthentication("SaSecurityScheme")
                    .AddCookie("SaSecurityScheme", options =>
                    {
                       options.AccessDeniedPath = new PathString("/Security/Access");
                       options.LoginPath = new PathString("/Security/Login");
                    });

         services.AddMvc();
      }

      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.UseAuthentication();
         app.UseMvcWithDefaultRoute();
      }
   }
}