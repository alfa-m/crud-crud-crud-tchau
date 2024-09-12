using TodoList.Models;

namespace TodoList.Services;

public static class TarefaService
{
    static List<Tarefa> Todo { get; }
    static int indiceAtual = 4;

    static TarefaService()
    {
        Todo = new List<Tarefa> {
            new Tarefa { Id = 1, Conteudo = "Fazer CRUD Todo List", EstaFeita = false },
            new Tarefa { Id = 2, Conteudo = "Enviar CRUD pro GitHub", EstaFeita = false },
            new Tarefa { Id = 3, Conteudo = "Tentar deploy em nuvem", EstaFeita = false },
        };
    }

    public static List<Tarefa> GetAll() => Todo;

    public static Tarefa? Get(int id) => Todo.FirstOrDefault(tarefa => tarefa.Id == id);

    public static void Add(Tarefa Tarefa)
    {
        tarefa.Id = indiceAtual;
        indiceAtual++;
        Todo.Add(Tarefa);
    }

    public static void Update(Tarefa Tarefa)
    {
        var indice = Todo.FindIndex(tarefa => tarefa.Id == Tarefa.Id);

        if (indice == -1)
            return;

        Todo[indice] = Tarefa;
    }

    public static void Delete(int id)
    {
        var tarefa = Get(id);

        if (tarefa is null)
            return;

        Todo.Remove(Tarefa);
    }
}