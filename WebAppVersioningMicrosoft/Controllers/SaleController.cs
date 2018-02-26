using Microsoft.AspNetCore.Mvc;

namespace WebAppVersioningMicrosoft.Controllers
{
   public class SaleController
   {
   }

   // Conventions specified in Startup
   // via HTTP header
   // e.g. /api/sale, add api-version header

   [Route("api/sale")]
   public class SaleControllerV1 : Controller
   {
      [HttpGet]
      public IActionResult Get() => Content("Version 1");
   }

   [Route("api/sale")]
   public class SaleControllerV2 : Controller
   {
      [HttpGet]
      public IActionResult Get() => Content("Version 2");
   }
}