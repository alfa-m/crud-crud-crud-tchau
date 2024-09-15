using TodoList.Models;
using TodoList.Services;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controllers;

[ApiController]
[Route("todo")]
public class TarefaController : ControllerBase
{
    public TarefaController() { }

    [HttpGet]
    public ActionResult<List<Tarefa>> GetAll() => TarefaService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Tarefa> Get(int id)
    {
        var tarefa = TarefaService.Get(id);
        if (tarefa == null)
            return NotFound();

        return tarefa;

    }

    [HttpPost]
    public IActionResult Create(Tarefa tarefa)
    {
        TarefaService.Add(tarefa);
        return CreatedAtAction(nameof(Get), new { id = tarefa.Id }, tarefa);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Tarefa tarefa)
    {
        if (id != tarefa.Id)
            return BadRequest();

        var tarefaExistente = TarefaService.Get(id);
        if (tarefaExistente is null)
            return NotFound();

        TarefaService.Update(tarefa);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var tarefaExistente = TarefaService.Get(id);
        if (tarefaExistente is null)
            return NotFound();

        TarefaService.Delete(id);
        return NoContent();
    }
}