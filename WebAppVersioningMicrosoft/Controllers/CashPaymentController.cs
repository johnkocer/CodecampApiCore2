using Microsoft.AspNetCore.Mvc;

namespace WebAppVersioningMicrosoft.Controllers
{
   // Deprecated
   // via HTTP header
   // e.g. api/cashPayment, add api-version header

   [ApiVersion("1.0", Deprecated = true)]
   [Route("api/cashPayment")]
   public class CashPaymentControllerV1 : Controller
   {
      [HttpGet]
      public IActionResult Get() => Content("Version 1");
   }

   [ApiVersion("2.0")]
   [Route("api/cashPayment")]
   public class CashPaymentControllerV2 : Controller
   {
      [HttpGet]
      public IActionResult Get() => Content("Version 2");
   }
}