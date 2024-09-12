using TodoList.Models;
using TodoList.Services;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    public TaskController() { }

    [HttpGet]
    public ActionResult<List<Task>> GetAll() => TaskService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Task> Get(int id)
    {
        var task = TaskService.Get(id);
        if (task == null)
            return NotFound();

        return task;

    }

    [HttpPost]
    public IActionResult Create(Task task)
    {
        TaskService.Add(task);
        return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Task task)
    {
        if (id != task.Id)
            return BadRequest();

        var tarefaExistente = TaskService.Get(id);
        if (tarefaExistente is null)
            return NotFound();

        TaskService.Update(task);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var tarefaExistente = TaskService.Get(id);
        if (tarefaExistente is null)
            return NotFound();

        TaskService.Delete(id);
        return NoContent();
    }
}