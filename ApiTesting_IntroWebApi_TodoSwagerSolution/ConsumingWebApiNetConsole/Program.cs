using System;
using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace ConsumingWebApiNetConsole
{
   class Program
   {
      static HttpClient client = new HttpClient();

      static void Main(string[] args)
      {
         RunAsync().GetAwaiter().GetResult();

      }

      static async Task RunAsync()
      {
         client.BaseAddress = new Uri("http://localhost:63274/");
         client.DefaultRequestHeaders.Accept.Clear();
         client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
         //GET- get the Todos
         List<Todo> todoList = new List<Todo>();
         HttpResponseMessage response = await client.GetAsync("api/GetAllTodos");
         if (response.IsSuccessStatusCode)
         {
            todoList = await response.Content.ReadAsJsonAsync<List<Todo>>();
         }

         // POST -create todo
         Todo todo = new Todo() { Name = "Call Mom" };
         var content = new StringContent(JsonConvert.SerializeObject(todo), Encoding.UTF8, "application/json");

         response = await client.PostAsync("api/AddTodo", content);
         if (response.IsSuccessStatusCode)
         {
            todo = await response.Content.ReadAsJsonAsync<Todo>();
         }

         // PUT -update todo
         int updateTodoId = 2;
         Todo updateTodo = null;
         response = await client.GetAsync($"api/GetTodo/{updateTodoId}");
         if (response.IsSuccessStatusCode)
         {
            updateTodo = await response.Content.ReadAsJsonAsync<Todo>();
            updateTodo.Name = updateTodo.Name + " -UPDATED";
         }
         content = new StringContent(JsonConvert.SerializeObject(updateTodo), Encoding.UTF8, "application/json");

         response = await client.PutAsync("api/UpdateTodo", content);
         if (response.IsSuccessStatusCode)
         {
            todo = await response.Content.ReadAsJsonAsync<Todo>();
         }

         // DELETE -DeleteTodo
         int deleteTodoId = 2;
         response = await client.DeleteAsync($"api/DeleteTodo/{deleteTodoId}");
         if (response.IsSuccessStatusCode)
         {
            response = await client.GetAsync("api/GetAllTodos");
            if (response.IsSuccessStatusCode)
            {
               todoList = await response.Content.ReadAsJsonAsync<List<Todo>>();
            }
         }
      }

      public class Todo
      {
         public int Id { get; set; }
         public string Name { get; set; }
      }
   }
   public static class HttpContentExtensions
   {
      public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
      {
         string json = await content.ReadAsStringAsync();
         T value = JsonConvert.DeserializeObject<T>(json);
         return value;
      }
   }
}
