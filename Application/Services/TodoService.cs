using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class TodoService
{
    private readonly ITodoRepository _repo;

    public TodoService(ITodoRepository repo)
    {
        _repo = repo;
    }

    public Task<List<TodoItem>> GetAllAsync()
        => _repo.GetAllAsync();

    public Task<TodoItem?> GetByIdAsync(int id)
        => _repo.GetByIdAsync(id);

    public Task AddAsync(TodoItem todo)
        => _repo.AddAsync(todo);

    public Task UpdateAsync(TodoItem todo)
        => _repo.UpdateAsync(todo);

    public Task DeleteAsync(int id)
        => _repo.DeleteAsync(id);
}