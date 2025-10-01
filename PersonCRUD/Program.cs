using Person.Routes;
using Person.Data;

var builder = WebApplication.CreateBuilder(args);

// PARA EXECUTAR: dotnet watch -lip https
// https://localhost:7162/swagger/index.html

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<PersonContext>(); //injeta conexão com BD

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPersonRoutes();

app.UseHttpsRedirection();
Console.WriteLine($"Environment atual: {app.Environment.EnvironmentName}");

app.Run();

