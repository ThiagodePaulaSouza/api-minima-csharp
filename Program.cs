using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using api_minima_csharp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Minima", Description = "Testando as parada :D", Version = "v1" }));
builder.Services.AddDbContext<BookDb>(options => options.UseInMemoryDatabase("items"));

builder.Services.AddCors(options => { });

var app = builder.Build();
app.UseCors(Guid.NewGuid().ToString());

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Minima"));

// EF TESTE
app.MapGet("/ef", async (BookDb db) => await db.Books.ToListAsync());
app.MapPost("/ef", async (BookDb db, Book book) =>
{
    await db.Books.AddAsync(book);
    await db.SaveChangesAsync();
    return Results.Created($"/ef/{book.Id}", book);
});


string bark()
{
    return "huf huf, auau";
}
var data = new Dictionary<int, string>() {
    {1, "salsichinha"},
    {2, "poodle"},
    {3, "pincher"},
    {4, "rottweiler"},
    {9999, "caramelo"}
};

app.MapGet("/", () => "api minima csharp :))");
app.MapGet("/dog", () => bark());
app.MapGet("/dog/{id}", (int id) => data.SingleOrDefault(dog => dog.Key == id));

List<Book> MeusLivros = new List<Book>();

app.MapGet("/book", () => MeusLivros.Select(o => o));
app.MapGet("/book/{id}", (int id) => MeusLivros.Single(o => o.Id == id));
app.MapPost("/book", (Book book) => MeusLivros.Add(book));
app.MapPut("/book/{id}", (int id, Book book) => MeusLivros[id] = book);
app.MapDelete("/book/{id}", (int id) => MeusLivros.Remove(MeusLivros.Single(o => o.Id == id)));

app.Run();