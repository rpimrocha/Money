using Microsoft.EntityFrameworkCore;
using Money.Api.Data;
using Money.Api.Endpoints;
using Money.Api.Handlers;
using Money.Core.Handlers;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });

builder.Services.AddTransient<ICategoriaHandler, CategoriaHandler>();
builder.Services.AddTransient<ITransacaoHandler, TransacaoHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => new { mensagem = "Olá Mundo!" });
app.MapEndponts();

app.Run();
