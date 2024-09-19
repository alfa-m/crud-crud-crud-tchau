using TodoList.Models;

namespace TodoList.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TarefaContext context)
        {

            if (context.Todo.Any())
            {
                return;
            }

            var todo = new Tarefa[] {
                new Tarefa { Id = 1, Conteudo = "Fazer CRUD Todo List", EstaFeita = true },
                new Tarefa { Id = 2, Conteudo = "Enviar CRUD pro GitHub", EstaFeita = true },
                new Tarefa { Id = 3, Conteudo = "Tentar deploy em nuvem", EstaFeita = false },
            };

            context.Todo.AddRange(todo);
            context.SaveChanges();
        }
    }
}