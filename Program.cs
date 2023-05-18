var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => { });

var app = builder.Build();

app.UseCors(Guid.NewGuid().ToString());

app.MapGet("/", () => "api minima csharp :DD");

app.Run();
