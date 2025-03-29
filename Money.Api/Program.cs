using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Money.Api.Data;

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
    "/transacoes",
    ([FromBody] Request request, Handler handler) => handler.Handle(request))
    .WithName("Transações: Criar")
    .WithSummary("Cria uma nova transação.")
    .Produces<Response>();

app.Run();


public class Request
{
    public string Titulo { get; set; } = string.Empty;
    public DateTime DataCadastro { get; set; } = DateTime.Now;
    public int Tipo { get; set; }
    public decimal Valor { get; set; }
    public long CodigoCategoria { get; set; }
    public string CodigoUsuario { get; set; } = string.Empty;
}

public class Response
{
    public int Codigo { get; set; }
    public string Titulo { get; set; } = string.Empty;
}

public class Handler
{
    public Response Handle(Request request)
    {
        return new Response
        {
            Codigo = 1,
            Titulo = request.Titulo
        };
    }
}
