﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.DependencyInjection;

namespace ConventionBasedRouting
{
   public class Startup
   {
      // This method gets called by the runtime. Use this method to add services to the container.
      // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddMvc();
         // Register the Swagger generator, defining one or more Swagger documents  
         services.AddSwaggerGen(c =>
         {
            c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
         });
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         //app.Run(async (context) =>
         //{
         //    await context.Response.WriteAsync("Hello World!");
         //});
         // Enable middleware to serve generated Swagger as a JSON endpoint.  
         app.UseSwagger();
         // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.  
         app.UseSwaggerUI(c =>
         {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
         });

         //app.UseMvc();

         //app.UseMvc(routes =>
         //{
         //   routes.MapRoute(
         //      name: "default",
         //      template: "api/{controller}/{action}/{id?}");
         //   //template: "{controller}");
         //});

         app.UseMvc(routes =>
         {
            routes.MapRoute(
               name: "api",
               template: "api/{controller=Hi}/{action=Get}/{id?}");

            routes.MapRoute(
               name: "default",
               template: "{controller}/{action}/{id?}");
         });
      }
   }
}
