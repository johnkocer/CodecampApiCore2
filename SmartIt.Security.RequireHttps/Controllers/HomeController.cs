using Microsoft.AspNetCore.Mvc;

namespace SmartIt.Security.RequireHttps.Controllers
{
   public class HomeController : Controller
   {
      public IActionResult Index()
      {
         return View();
      }
   }
}