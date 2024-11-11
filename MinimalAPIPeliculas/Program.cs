using Microsoft.AspNetCore.Mvc;
using MinimalAPIPeliculas.Entidades;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOutputCache();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
} 

app.UseOutputCache();

app.MapGet("/", () => "Hello World!");

app.MapGet("/generos", () =>
{
    var generos = new List<Genero>
    {
        new Genero { Id = 1, Nombre = "Drama" },
        new Genero { Id = 2, Nombre = "Acción" },
        new Genero { Id = 3, Nombre = "Comedia" },
    };

    return generos;
}).CacheOutput(c => c.Expire(TimeSpan.FromSeconds(15)));

app.Run();
