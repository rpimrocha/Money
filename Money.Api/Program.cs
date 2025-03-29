using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Money.Api.Data;
using Money.Core.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });

builder.Services.AddTransient<Handler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapPost(
    "/v1/categorias",
    ([FromBody] Request request, Handler handler) => handler.Handle(request))
    .WithName("Categorias: Criar")
    .WithSummary("Cria uma nova categoria.")
    .Produces<Response>();

app.Run();


public class Request
{
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
}

public class Response
{
    public long Codigo { get; set; }
    public string Titulo { get; set; } = string.Empty;
}

public class Handler(AppDbContext context)
{
    public Response Handle(Request request)
    {
        var categoria = new Categoria { Titulo = request.Titulo, Descricao = request.Descricao };
        context.Categorias.Add(categoria);
        context.SaveChanges();

        return new Response
        {
            Codigo = categoria.Codigo,
            Titulo = categoria.Titulo
        };
    }
}
