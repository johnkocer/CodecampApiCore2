//Copyright 2018 (c) SmartIT. All rights reserved.
//By John Kocer
// This file is for Swagger test, this application does not use this file
using Microsoft.AspNetCore.Mvc;
using SmartIT.Employee.MockDB;

namespace TodoAngular.Ui.Controllers
{
   [Produces("application/json")]
   [Route("api/Employee")]
   public class EmployeeController : Controller
   {
      private EmployeeRepository db = new EmployeeRepository();
      // api/GetEmployees
      [Route("~/api/GetEmployees")]
      [HttpGet]
      public IActionResult GetEmployees()
      {
         return Ok(db.GetAll());
      }
      //api/GetEmployee/2
      [Route("~/api/GetEmployee/{id}")]
      [HttpGet]
      public IActionResult Get(int id)
      {
         var findEmployee = db.FindbyId(id);
         if (findEmployee == null)
            return NotFound();
         else
            return Ok(findEmployee);
      }
      // api/AddEmployee
      [Route("~/api/AddEmployee")]
      [HttpPost]
      public IActionResult AddEmployee([FromBody]Employee item)
      {
         if (item == null)
            return BadRequest();
         else
         {
            db.Add(item);
            return new CreatedResult($"/api/AddEmployee", item);
         }
      }
      // api/UpdateEmployee/4
      [Route("~/api/UpdateEmployee")]
      [HttpPut]
      public IActionResult UpdateEmployee(int id, [FromBody]Employee item)
      {
         if (item == null || id != item.Id)
            return BadRequest();
         else
         {
            db.Update(item);
            return new CreatedResult($"/api/UpdateEmployee/{item.Id}", item);
         }
      }
      // api/DeleteEmployee/5
      [Route("~/api/DeleteEmployee/{id}")]
      [HttpDelete]
      public IActionResult Delete(int id)
      {
         var findEmployee = db.FindbyId(id);
         if (findEmployee == null)
            return NotFound();
         else
         {
            db.Delete(findEmployee);
            return NoContent();
         }
      }
   }
}