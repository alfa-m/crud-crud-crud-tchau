using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Data;

public class TarefaContext : DbContext
{
    public TarefaContext(DbContextOptions<TarefaContext> options)
        : base(options)
    {

    }

    public DbSet<Tarefa> Todo => Set<Tarefa>();
}