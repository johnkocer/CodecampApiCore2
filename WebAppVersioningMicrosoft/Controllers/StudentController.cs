﻿using Microsoft.AspNetCore.Mvc;

namespace WebAppVersioningMicrosoft.Controllers
{
   // via query string
   // e.g. api/student?api-version=2.0

   [ApiVersion("1.0")]
   [Route("api/student")]
   public class StudentControllerV1 : Controller
   {
      [HttpGet]
      public IActionResult Get() => Content("Version 1");
   }

   [ApiVersion("2.0")]
   [Route("api/student")]
   public class StudentControllerV2 : Controller
   {
      [HttpGet]
      public IActionResult Get() => Content("Version 2");
   }
}