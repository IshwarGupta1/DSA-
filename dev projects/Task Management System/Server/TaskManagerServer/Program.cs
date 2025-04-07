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

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<TaskEntityDTOValidator>();

builder.Services.AddDbContext<TaskDataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskUpdateStrategy, UpdateFullTaskStrategy>();
builder.Services.AddScoped<ITaskUpdateStrategy, UpdateDueDateStrategy>();
builder.Services.AddScoped<ITaskUpdateStrategy, UpdateTaskStatusStrategy>();
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
