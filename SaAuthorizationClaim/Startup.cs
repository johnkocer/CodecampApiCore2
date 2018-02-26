using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using SaAuthorizationClaim.Auth;

namespace SaAuthorizationClaim
{
   public class Startup
   {
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddDistributedMemoryCache();
         services.AddSession();
         services.AddAuthentication("SaSecurityScheme")
                    .AddCookie("SaSecurityScheme", options =>
                    {
                       options.AccessDeniedPath = new PathString("/Security/Access");
                       options.LoginPath = new PathString("/Security/Login");
                    });

         services.AddAuthorization(options =>
         {
            options.AddPolicy("Authenticated", policy => policy.RequireAuthenticatedUser());

            options.AddPolicy("User", policy => policy.RequireClaim("User"));
            options.AddPolicy("Manager", policy => policy.RequireClaim("Manager"));
            options.AddPolicy("SiteAdmin", policy => policy.RequireClaim("SiteAdmin"));
            options.AddPolicy("SystemAdmin", policy => policy.RequireClaim("SystemAdmin"));
            //options.AddPolicy("HasExpenseCredit", policy => policy.RequireClaim("HasExpenseCredit"));
            options.AddPolicy("CanGiveBonus", policy => policy.RequireClaim("CanGiveBonus"));
            options.AddPolicy("HasExpenseCredit", policy => policy.Requirements.Add(new ManagerPayExpenseRequirement()));

            options.AddPolicy("AtLeast21", policy => policy.Requirements.Add(new MinimumAgeRequirement(21)));
         });

         services.AddScoped<IAuthorizationHandler, AdminRequirementHandler>();
         services.AddScoped<IAuthorizationHandler, ManagerPayExpenseRequirementHandler>();
         services.AddMvc(options =>
         {
            options.Filters.Add(new AuthorizeFilter("Authenticated"));
         });
      }

      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         app.UseSession();
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.UseAuthentication();
         app.UseMvcWithDefaultRoute();
      }
   }
}