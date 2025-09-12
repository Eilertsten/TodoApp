namespace TodoApp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public bool Is_Done { get; set; }  // note: matches `is_done` in DB
    }
}

