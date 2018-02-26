using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConventionBasedRouting
{
   [Produces("application/json")]
   //[Route("api/[controller]/[action]")]
   //[Route("api/[controller]/[action]/{id?}")]
   public class HiControllerOK : Controller
   {
      // GET api/hi/get
      [HttpGet]
      public IEnumerable<string> Get()
      {
         return new string[] { "hi1", "hi2" };
      }

      // GET api/hi/getById/5
      //[HttpGet("{id}")]
      //[HttpGet]
      public string GetById(int id)
      {
         return "HI - " + id.ToString();
      }

      //POST api/hi/post/
      // application/json - body "Hello"
      //[HttpPost]
      public string Post([FromBody]string value)
      {
         return value;
      }

      // PUT api/values/5
      // application/json - body "Hello"
      //[HttpPut]
      //[HttpPut("{id}")]
      public string Put(int id, [FromBody]string value)
      {
         return value;
      }

      // DELETE api/values/5
      //[HttpDelete]
      //[HttpDelete("{id}")]
      public string Delete(int id)
      {
         return id.ToString();
      }
   }
}
