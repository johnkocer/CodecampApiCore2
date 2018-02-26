using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIt.WebApi.Controllers
{
   [Route("api/[controller]")]
   public class ValuesController : Controller
   {
      // GET api/values
      [Route("~/api/values/get")]

      [HttpGet]
      public async Task<IActionResult> Get()
      {
         List<string> values = new List<string>() { "value1", "value2" };
         return Ok(values);
      }

      [Route("~/api/values/post")]
      [HttpPost]
      public async Task<IActionResult> Post([FromBody]string value)
      {
         return Created("", value);
      }
   }
}