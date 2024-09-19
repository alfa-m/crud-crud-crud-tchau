using TodoList.Models;
using TodoList.Services;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controllers;

[ApiController]
[Route("todo")]
public class TarefaController : ControllerBase
{
    TarefaService _service;

    public TarefaController(TarefaService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Tarefa> GetAll(){
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Tarefa> GetById(int id)
    {
        var tarefa = _service.GetById(id);
        if (tarefa is not null){
            return tarefa;
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult Create(Tarefa novaTarefa)
    {
        var tarefa = _service.Create(novaTarefa);
        return CreatedAtAction(nameof(GetById), new { id = tarefa!.Id }, tarefa);
    }

    [HttpPut("{id}/updatestatus")]
    public IActionResult UpdateStatus(int id)
    {
        var tarefaParaAtualizar = _service.GetById(id);

        if (tarefaParaAtualizar is not null){
            _service.UpdateStatus(id);
            return NoContent();

        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var tarefaParaApagar = _service.GetById(id);
        if (tarefaParaApagar is not null){
            _service.DeleteById(id);
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }
}