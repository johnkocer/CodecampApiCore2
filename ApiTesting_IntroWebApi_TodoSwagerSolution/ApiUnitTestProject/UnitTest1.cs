using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace ApiUnitTestProject
{
   [TestClass]
   public class ApiUnitTest1
   {
      private const string _baseUri = "http://localhost:63274/";

      [TestMethod]
      public async Task TestMethod1()
      {
         //arrange
         using(HttpClient client= new HttpClient())
         {
            client.BaseAddress = new Uri(_baseUri);
            //act
            HttpResponseMessage response = await client.GetAsync("api/GetAllTodos");

            var result = response.Content.ReadAsStringAsync();
            // assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
         }
      }
   }
}
