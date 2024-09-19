namespace TodoList.Models;

public class Tarefa
{
    public int Id { get; set; }
    public string Conteudo { get; set; } = "Insira uma tarefa";
    public bool EstaFeita { get; set; } = false;
}