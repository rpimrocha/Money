using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Money.Api.Data;
using Money.Api.Handlers;
using Money.Core.Handlers;
using Money.Core.Models;
using Money.Core.Requests.Categorias;
using Money.Core.Responses;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });

builder.Services.AddTransient<ICategoriaHandler, CategoriaHandler>();

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
    async ([FromBody] InserirCategoriaRequest request, ICategoriaHandler handler) => await handler.InserirAsync(request))
    .WithName("Categorias: Inserir")
    .WithSummary("Inserir uma nova categoria.")
    .Produces<Response<Categoria?>>();

app.MapPut(
    "/v1/categorias/{codigo}",
    async (long codigo, [FromBody] AlterarCategoriaRequest request, ICategoriaHandler handler) => 
    {
        request.Codigo = codigo;
        return await handler.AlterarAsync(request);
    })
    .WithName("Categorias: Alterar")
    .WithSummary("Alterar uma categoria.")
    .Produces<Response<Categoria?>>();

app.MapDelete(
    "/v1/categorias/{codigo}",
    async (long codigo, ICategoriaHandler handler) =>
    {
        ApagarCategoriaRequest request = new()
        {
            Codigo = codigo,
            CodigoUsuario = "rirdopim@msn.com"
        };
        await handler.ApagarAsync(request);
    })
    .WithName("Categorias: Apagar")
    .WithSummary("Apagar uma categoria.")
    .Produces<Response<Categoria?>>();

app.MapGet(
    "/v1/categorias/{codigo}",
    async (long codigo, ICategoriaHandler handler) =>
    {
        SelecionarCategoriaPorCodigoRequest request = new()
        {
            Codigo = codigo,
            CodigoUsuario = "ricardopim@msn.com"
        };
        return await handler.SelecionarPorCodigoAsync(request);
    })
    .WithName("Categorias: Selecionar por código")
    .WithSummary("Selecionar uma categoria pelo código.")
    .Produces<Response<Categoria?>>();

app.MapGet(
    "/v1/categorias",
    async (ICategoriaHandler handler) =>
    {
        SelecionarTodasCategoriasRequest request = new()
        {
            CodigoUsuario = "ricardopim@msn.com"
        };
        return await handler.SelecionarTodosAsync(request);
    })
    .WithName("Categorias: Selecionar todas")
    .WithSummary("Selecionar todas as categorias.")
    .Produces<PagedResponse<List<Categoria>?>>();


app.Run();
