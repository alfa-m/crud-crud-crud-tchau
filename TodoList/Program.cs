using TodoList.Data;
using TodoList.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlite<TarefaContext>("Data Source=TodoList.db");

builder.Services.AddScoped<TarefaService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.CreateDbIfNotExists();

app.MapGet("/", () => @"API TodoList. Acesse /swagger para ver a interface de teste do Swagger.");

app.Run();
