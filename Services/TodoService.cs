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
                IsDone = false
            });
        }

        public void ToggleDone(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null) todo.IsDone = !todo.IsDone;
        }

        public void Remove(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null) _todos.Remove(todo);
        }
    }
}
