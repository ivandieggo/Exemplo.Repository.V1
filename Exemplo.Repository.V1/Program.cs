using Exemplo.Repository.V1.Interfaces;
using Exemplo.Repository.V1.Models;
using Exemplo.Repository.V1.Repository;
using Exemplo.Repository.V1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Contexto do Banco de Dados
builder.Services.AddDbContext<RepositoryPatternContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddMvc();

// Injeção de Dependência
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MY API");
});

app.UseHttpsRedirection();

// Minimal API
app.MapGet("/Product/{id}", ([FromRoute] int id, [FromServices] IRepository<Product> product) =>
{
    ProductService service = new ProductService(product);

    return Results.Ok(service.GetProductById(id));
});


app.MapPost("/Product/{id}", ([FromBody] Product model, [FromServices] IRepository<Product> product) =>
{
    ProductService service = new ProductService(product);
    service.AddProduct(model);

    return Results.Created($"/products/{model.Id}", model.Id);
});

app.Run();

