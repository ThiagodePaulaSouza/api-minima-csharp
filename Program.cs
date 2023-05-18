var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "api minima csharp :DD");

app.Run();
