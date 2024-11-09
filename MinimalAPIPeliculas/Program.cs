using MinimalAPIPeliculas.Entidades;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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
});

app.Run();
