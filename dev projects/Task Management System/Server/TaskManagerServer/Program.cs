using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TaskManagerServer.Data;
using TaskManagerServer.Repository;
using TaskManagerServer.Service;
using TaskManagerServer.Services;
using TaskManagerServer.Strategies;
using TaskManagerServer.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add In-Memory Database for Testing
//builder.Services.AddDbContext<TaskDataContext>(options =>
//options.UseInMemoryDatabase("TaskDb"));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskUpdateStrategy, UpdateFullTaskStrategy>();
builder.Services.AddScoped<ITaskUpdateStrategy, UpdateDueDateStrategy>();
builder.Services.AddScoped<ITaskUpdateStrategy, UpdateTaskStatusStrategy>();
builder.Services.AddValidatorsFromAssemblyContaining<TaskEntityDTOValidator>();

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        builder => builder
            .AllowAnyOrigin()  // For testing, allow all origins
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use CORS
app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
