using System.ComponentModel.DataAnnotations;

namespace TodoList.Models;

public class Tarefa
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Conteudo { get; set; } = "Insira a tarefa";
    public bool EstaFeita { get; set; } = false;
}