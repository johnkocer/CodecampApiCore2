using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CustomMiddleware
{
   public class Startup
   {
      public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory, IConfiguration config)
      {
      }

      public void ConfigureServices(IServiceCollection services)
      {
      }

      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         app.UseMiddleware1();
         app.UseMiddleware2InClass();
         app.RunMiddleware3();
      }
   }
}