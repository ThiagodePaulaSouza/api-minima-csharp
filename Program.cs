using Microsoft.OpenApi.Models;
;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Minima", Description = "Testando as parada :D", Version = "v1" }));

builder.Services.AddCors(options => { });

var app = builder.Build();
app.UseCors(Guid.NewGuid().ToString());

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Minima"));

app.MapGet("/", () => "api minima csharp :))");

app.Run();
