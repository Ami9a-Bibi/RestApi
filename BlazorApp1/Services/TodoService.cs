using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using BlazorApp1.Services;

public class TodoService
{
    private readonly HttpClient _httpClient;

    public TodoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<List<TodoItem>> GetTodosAsync()
    {
        try
        {
            // Combine BaseAddress with the relative URL
            string apiUrl = new Uri(_httpClient.BaseAddress, "api/Todo").ToString();
            Console.WriteLine($"Received request for todos. API URL: {apiUrl}");

            var todos = await _httpClient.GetFromJsonAsync<List<TodoItem>>("api/Todo");
            Console.WriteLine($"Fetched GetTodosAsync {todos?.Count ?? 0} todos");
            return todos;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching todos: {ex.Message}");
            return new List<TodoItem>();
        }
    }




    public async Task<TodoItem?> GetTodoByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<TodoItem>($"api/Todo/{id}");
    }

    public async Task AddTodoAsync(TodoItem newTodo)
    {
        await _httpClient.PostAsJsonAsync("api/Todo", newTodo);
    }

    public async Task UpdateTodoAsync(TodoItem updatedTodo)
    {
        await _httpClient.PutAsJsonAsync($"api/Todo/{updatedTodo.Id}", updatedTodo);
    }

    public async Task DeleteTodoAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/Todo/{id}");
    }
}
