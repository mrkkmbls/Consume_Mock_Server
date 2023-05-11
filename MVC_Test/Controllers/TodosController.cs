﻿using Microsoft.AspNetCore.Mvc;
using MVC_Test.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVC_Test.Controllers
{
    public class TodosController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public IEnumerable<Todo> Todos { get; set; }

        string baseURL = "https://jsonplaceholder.typicode.com/";

        HttpClient httpClient = new HttpClient();

        public TodosController()
        {

        }


        public List<Todo> GetAllTodos()
        {
            // fetch todos from rest service -> http request message
            // http://localhost:30010/api/v1/todos
            var response = httpClient.GetAsync(baseURL + "/todos").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;// json standard
                // any json http response can be converted to a C# object by doing a
                // serialization -> convert c# object to other data type [json, xml, paintext]
                // deserialization -> convert other data type [json, xml, paintext] to C# object

                // newtonsoft library which does serial deserial 
                List<Todo> todos = JsonConvert.DeserializeObject<List<Todo>>(data);
                return todos;
            }
            return null;
        }

        public Todo GetTodoById(int Id)
        {
            var response = httpClient.GetAsync(baseURL + "/todos/" +Id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;// json standard
                Todo todo = JsonConvert.DeserializeObject<Todo>(data);
                return todo;
            }
            return null;
        }
    }
}