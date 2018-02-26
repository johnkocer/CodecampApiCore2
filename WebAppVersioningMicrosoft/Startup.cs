using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAppVersioningMicrosoft.Controllers;

namespace WebAppVersioningMicrosoft
{
   public class Startup
   {
      //public Startup(IConfiguration configuration)
      //{
      //   Configuration = configuration;
      //}

      public IConfiguration Configuration { get; }

      public void ConfigureServices(IServiceCollection services)
      {
         services.AddApiVersioning(options =>
         {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ApiVersionReader = new HeaderApiVersionReader("api-version");

            // convention-based setup
            options.Conventions.Controller<SaleControllerV1>().HasApiVersion(new ApiVersion(1, 0));
            options.Conventions.Controller<SaleControllerV2>().HasApiVersion(new ApiVersion(2, 0));
         });

         services.AddMvc();
      }

      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         app.UseMvc();
      }
   }
}