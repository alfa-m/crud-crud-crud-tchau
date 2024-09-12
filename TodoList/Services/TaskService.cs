using TodoList.Models;

namespace TodoList.Services;

public static class TaskService
{
    static List<Task> Todo { get; }
    static int indiceAtual = 4;

    static TaskService()
    {
        Todo = new List<Task> {
            new Task { Id = 1, Conteudo = "Fazer CRUD Todo List", estaFeita = false },
            new Task { Id = 2, Conteudo = "Enviar CRUD pro GitHub", estaFeita = false },
            new Task { Id = 3, Conteudo = "Tentar deploy em nuvem", estaFeita = false },
        };
    }

    public static List<Task> GetAll() => Todo;

    public static Task? Get(int id) => Todo.FirstOrDefault(tarefa => tarefa.Id == id);

    public static void Add(Task task)
    {
        tarefa.Id = indiceAtual;
        indiceAtual++;
        Todo.Add(task);
    }

    public static void Update(int id, Task task)
    {
        var indice = Todo.FindIndex(tarefa => tarefa.Id == task.Id);

        if (indice == -1)
            return;

        Todo[indice] = task;
    }

    public static void Delete(int id)
    {
        var tarefa = Get(id);

        if (tarefa is null)
            return;

        Todo.Remove(task);
    }
}