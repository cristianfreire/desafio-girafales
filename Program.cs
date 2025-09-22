using desafio_girafales.Infraestrutura;
using Microsoft.EntityFrameworkCore;
using desafio_girafales.Dominio.ModelViews;
using desafio_girafales.Dominio.Interfaces;
using desafio_girafales.Dominio.Servicos;

#region Builder
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProfessorServico, ProfessorServico>();
builder.Services.AddScoped<ISalaServico, SalaServico>();


// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContexto>(options =>
    options.UseSqlite("Data Source=university.db"));

var app = builder.Build();
#endregion


app.MapGet("/", () => Results.Json(new Home())).AllowAnonymous().WithTags("Home");


app.MapGet("/professores/horas", (IProfessorServico professorServico) =>
{
    var resultado = professorServico.HorasComprometidas();
    return Results.Ok(resultado);
})
.WithTags("Relatórios");

app.MapGet("/classes/todas", (ISalaServico salaServico) =>
{
    var salas = salaServico.ObterStatusSalas();
    return Results.Ok(salas);
}).WithTags("Relatórios");

app.MapGet("/professores/todos", (IProfessorServico professorServico) =>
{
    var professores = professorServico.Todos();
    return Results.Ok(professores);
}).WithTags("Professores");



#region App
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();
#endregion