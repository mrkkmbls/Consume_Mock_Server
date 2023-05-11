using Microsoft.AspNetCore.Mvc;
using MVC_Test.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
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
            var response = httpClient.GetAsync(baseURL + "/todos").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;// json standard
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

        public Todo UpdateTodo(int todoId, Todo newTodo)
        {
            string data = JsonConvert.SerializeObject(newTodo);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync(baseURL + "/todos/" + todoId, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                Todo todo = JsonConvert.DeserializeObject<Todo>(responsecontent);
                return todo;
            }
            return null;
        }
    }
}
