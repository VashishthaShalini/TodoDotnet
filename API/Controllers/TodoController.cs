using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Domain.Entities;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly TodoService _service;

    public TodoController(TodoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var todos = await _service.GetAllAsync();
        return Ok(todos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var todo = await _service.GetByIdAsync(id);
        if (todo == null) return NotFound();
        return Ok(todo);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TodoItem todo)
    {
        await _service.AddAsync(todo);
        return Ok(todo);
    }

    [HttpPut]
    public async Task<IActionResult> Update(TodoItem todo)
    {
        await _service.UpdateAsync(todo);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
}