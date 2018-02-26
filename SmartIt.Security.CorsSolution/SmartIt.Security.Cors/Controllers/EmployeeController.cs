﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SmartIt.Security.Cors
{
   [Produces("application/json")]
   //[Route("api/[controller]")]
   public class EmployeeController : Controller
   {
      [EnableCors("SmartIt")]
      [Route("~/api/GetEmployees")]
      [HttpGet]
      public string GetEmployees()
      {
         return "All employees";
      }

      [Route("~/api/GetEmployee/{id}")]
      [HttpGet]
      //[DisableCors]
      public IActionResult Get(int id)
      {
         return Content($"Employee {id}");
      }
   }
}