using Microsoft.AspNetCore.Mvc;

namespace SmartIT.EmployeeApiVersioning.Controllers
{
   [Produces("application/json")]
   [Route("api/Employee")]
   public class EmployeeController : Controller
   {
      // GET: api/Employee
      [Route("~/api/GetName")]
      [HttpGet]
      public string GetName()
      {
         return new Models.Employee() { Name = "Mike Koch" }.Name;
      }
   }
}