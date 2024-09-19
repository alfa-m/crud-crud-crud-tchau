using TodoList.Models;
using TodoList.Data;
using Microsoft.EntityFrameworkCore;

namespace TodoList.Services;

public class TarefaService
{
    private readonly TarefaContext _context;

    public TarefaService(TarefaContext context)
    {
        _context = context;
    }

    public IEnumerable<Tarefa> GetAll()
    {
        return _context.Todo
            .AsNoTracking()
            .ToList();
    }

    public Tarefa? GetById(int id)
    {
        return _context.Todo
            .AsNoTracking()
            .SingleOrDefault(t => t.Id == id);
    }

    public Tarefa Create(Tarefa novaTarefa)
    {
        _context.Todo.Add(novaTarefa);
        _context.SaveChanges();

        return novaTarefa;
    }

    public void UpdateTask(int id, Tarefa tarefaAtualizada)
    {
        var tarefaParaAtualizar = _context.Todo.Find(id);

        if (tarefaParaAtualizar is null)
        {
            throw new InvalidOperationException("Não existe tarefa com o id informado");
        }

        tarefaParaAtualizar.Conteudo = tarefaAtualizada.Conteudo;
        tarefaParaAtualizar.EstaFeita = tarefaAtualizada.EstaFeita;

        _context.SaveChanges();
    }

    public void UpdateStatus(int id)
    {
        var tarefaParaAtualizar = _context.Todo.Find(id);

        if (tarefaParaAtualizar is null)
            throw new InvalidOperationException("Não existe tarefa com o id informado");

        tarefaParaAtualizar.EstaFeita = !(tarefaParaAtualizar.EstaFeita);

        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var tarefaParaApagar = _context.Todo.Find(id);
        if (tarefaParaApagar is not null)
        {
            _context.Todo.Remove(tarefaParaApagar);
            _context.SaveChanges();
        }
    }
}