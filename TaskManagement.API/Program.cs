using TaskManagement.Infrastructure.Persistence;
using TaskManagement.Application.Services;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Repositories;
using MongoDB.Driver;
using DotNetEnv;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;

var builder = WebApplication.CreateBuilder(args);

// Cargar variables de entorno
Env.Load();

var mongoConnectionString = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING");
var databaseName = Environment.GetEnvironmentVariable("DATABASE_NAME");

// Registrar servicios en el contenedor
builder.Services.AddSingleton<IMongoClient, MongoClient>(_ => new MongoClient(mongoConnectionString));
builder.Services.AddScoped<IMongoDatabase>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(databaseName);
});
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddHttpClient<IAuthenticationService, AuthenticationService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configuración de Swagger con ejemplo personalizado para TaskItem
builder.Services.AddSwaggerGen(options =>
{
    // Agregar documentación en XML
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    // Definir un ejemplo de TaskItem sin el campo "id"
    options.MapType<TaskItem>(() => new OpenApiSchema
    {
        Example = new OpenApiObject
        {
            ["title"] = new OpenApiString("Mi tarea de ejemplo"),
            ["description"] = new OpenApiString("Descripción de la tarea"),
            ["dueDate"] = new OpenApiString("2025-01-20T04:00:36.824Z"),
            ["status"] = new OpenApiInteger(0) 
        }
    });
});

var app = builder.Build();

// Configurar middlewares
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
