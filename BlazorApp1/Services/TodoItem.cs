namespace BlazorApp1.Services
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; } // New field

        public bool IsCompleted { get; set; }
    }
}
