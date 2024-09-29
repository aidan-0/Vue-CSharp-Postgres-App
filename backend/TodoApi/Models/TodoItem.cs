namespace TodoApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public bool Completed { get; set; }
    }
}
