using TodoList.Models;
using TodoList.Data;
using Microsoft.EntityFrameworkCore;

namespace TodoList.Services;

public class TarefaService
{
    /*
    static List<Tarefa> Todo { get; }
    static int indiceAtual = 4;

    static TarefaService()
    {
        Todo = new List<Tarefa> {
            new Tarefa { Id = 1, Conteudo = "Fazer CRUD Todo List", EstaFeita = true },
            new Tarefa { Id = 2, Conteudo = "Enviar CRUD pro GitHub", EstaFeita = true },
            new Tarefa { Id = 3, Conteudo = "Tentar deploy em nuvem", EstaFeita = false },
        };
    }

    public static List<Tarefa> GetAll() => Todo;

    public static Tarefa? Get(int id) => Todo.FirstOrDefault(t => t.Id == id);

    public static void Add(Tarefa tarefa)
    {
        tarefa.Id = indiceAtual;
        indiceAtual++;
        Todo.Add(tarefa);
    }

    public static void Update(Tarefa tarefa)
    {
        var indice = Todo.FindIndex(t => t.Id == tarefa.Id);

        if (indice == -1)
            return;

        Todo[indice] = tarefa;
    }

    public static void Delete(int id)
    {
        var tarefa = Get(id);

        if (tarefa is null)
            return;

        Todo.Remove(tarefa);
    }
    */

    private readonly TarefaContext _context;
    
    public TarefaService(TarefaContext context){
        _context = context;
    }

    public IEnumerable<Tarefa> GetAll(){
        return _context.Todo
            .AsNoTracking()
            .ToList();
    }

    public Tarefa? GetById(int id){
        return _context.Todo
            .AsNoTracking()
            .SingleOrDefault(t => t.Id == id);
    }

    public Tarefa Create(Tarefa novaTarefa){
        _context.Todo.Add(novaTarefa);
        _context.SaveChanges();

        return novaTarefa;
    }

    public void UpdateStatus(int id){
        var tarefaParaAtualizar = _context.Todo.Find(id);

        if (tarefaParaAtualizar is null)
            throw new InvalidOperationException("Não existe tarefa com o id informado");

        tarefaParaAtualizar.EstaFeita = !(tarefaParaAtualizar.EstaFeita);

        _context.SaveChanges();
    }

    public void DeleteById(int id){
        var tarefaParaApagar = _context.Todo.Find(id);
        if(tarefaParaApagar is not null){
            _context.Todo.Remove(tarefaParaApagar);
            _context.SaveChanges();
        }
    }
}