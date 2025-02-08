using ToDoListBlazor.Services;
using ToDoListBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoListBlazor.APIs
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todoService;

        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> Get() => await _todoService.GetAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> Get(string id) => await _todoService.GetAsync(id);

        [HttpPost]
        public async Task<IActionResult> Create(TodoItem todo)
        {
            await _todoService.CreateAsync(todo);
            return CreatedAtAction(nameof(Get), new { id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, TodoItem todo)
        {
            await _todoService.UpdateAsync(id, todo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _todoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
