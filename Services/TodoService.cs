using System.Collections.Generic;
using System.Linq;
using TodoApp.Models;

namespace TodoApp.Services
{
    public class TodoService
    {
            private readonly List<TodoItem> _todos = new List<TodoItem>();
            private int _nextId = 1;

            public List<TodoItem> GetAll() => _todos;

            public void Add(string title)
            {
                _todos.Add(new TodoItem
                {
                    Id = _nextId++,
                    Title = title,
                    Is_Done = false
                });
            }

            public void ToggleDone(int id)
            {
                var todo = _todos.FirstOrDefault(t => t.Id == id);
                if (todo != null) todo.Is_Done = !todo.Is_Done;
            }

            public void Remove(int id)
            {
                var todo = _todos.FirstOrDefault(t => t.Id == id);
                if (todo != null) _todos.Remove(todo);
            }
    }
     
    //Supabase pwd: SenjaToDo2025!
    //https://lpwfeklbrbzylxqhdctp.supabase.co
    //eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Imxwd2Zla2xicmJ6eWx4cWhkY3RwIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NTc2NTY2NjgsImV4cCI6MjA3MzIzMjY2OH0.BcKRMBV38T2GQ2QtsY5jBobICOA0vWqJtsMU9MQNxLU
}
