using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class TodoContext : IdentityDbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

        // Your DbSet<TodoItem> for TodoItems
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
