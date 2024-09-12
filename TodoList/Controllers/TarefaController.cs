using TodoList.Models;
using TodoList.Services;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controllers;

[ApiController]
[Route("[controller]")]
public class TarefaController : ControllerBase
{
    public TarefaController() { }

    [HttpGet]
    public ActionResult<List<Tarefa>> GetAll() => TarefaService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Tarefa> Get(int id)
    {
        var Tarefa = TarefaService.Get(id);
        if (Tarefa == null)
            return NotFound();

        return Tarefa;

    }

    [HttpPost]
    public IActionResult Create(Tarefa Tarefa)
    {
        TarefaService.Add(Tarefa);
        return CreatedAtAction(nameof(Get), new { id = Tarefa.Id }, Tarefa);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Tarefa Tarefa)
    {
        if (id != Tarefa.Id)
            return BadRequest();

        var tarefaExistente = TarefaService.Get(id);
        if (tarefaExistente is null)
            return NotFound();

        TarefaService.Update(Tarefa);
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