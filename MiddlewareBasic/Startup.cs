using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MiddlewareBasic
{
   public class Startup
   {
      public void ConfigureServices(IServiceCollection services)
      {
      }

      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         app.Use(async (context, next) =>
         {
            await context.Response.WriteAsync("<br/>Middleware 1-------------------><br/>");
            // Calls next middleware in pipeline
            await next.Invoke();
         });
         app.Use(async (context, next) =>
         {
            await context.Response.WriteAsync("Middleware 2-------------------><br/>");
            // Calls next middleware in pipeline
            await next.Invoke();
         });
         app.Use(async (context, next) =>
         {
            await context.Response.WriteAsync("Middleware 3-------------------><br/>");
            // Calls next middleware in pipeline
            await next.Invoke();
         });
         app.Use(async (context, next) =>
         {
            await context.Response.WriteAsync("Middleware 4-------------------><br/>");
            // Calls next middleware in pipeline
            //await next.Invoke();
         });
         //app.Run(async (context) =>
         //{
         //   await context.Response.WriteAsync("Hello World!");
         //});
      }
   }
}