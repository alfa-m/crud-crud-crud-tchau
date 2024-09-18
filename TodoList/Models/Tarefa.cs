using System.ComponentModel.DataAnnotations;

namespace TodoList.Models;

public class Tarefa
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Conteudo { get; set; }
    public bool EstaFeita { get; set; }
}