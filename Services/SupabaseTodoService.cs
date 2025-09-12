using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using TodoApp.Models;

namespace TodoApp.Services
{
    public class SupabaseTodoService
    {
        private readonly HttpClient _http;

        public SupabaseTodoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TodoItem>> GetTodos()
        {
            var todos = await _http.GetFromJsonAsync<List<TodoItem>>("rest/v1/todos?select=*");
            return todos ?? new List<TodoItem>();
        }

        public async Task AddTodo(string title)
        {
            var todo = new { title, is_done = false };
            await _http.PostAsJsonAsync("rest/v1/todos", todo);
        }

        public async Task ToggleTodo(int id, bool isDone)
        {
            var update = new { is_done = !isDone };
            await _http.PatchAsJsonAsync($"rest/v1/todos?id=eq.{id}", update);
        }

        public async Task DeleteTodo(int id)
        {
            await _http.DeleteAsync($"rest/v1/todos?id=eq.{id}");
        }
    }
}
