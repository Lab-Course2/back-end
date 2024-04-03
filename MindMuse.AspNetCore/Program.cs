using System.Globalization;
using MindMuse.Application.Filters;
using MindMuse.Application;
using MindMuse.Data;
using MindMuse.Application.Contracts.Interfaces;
using MindMuse.Application.Contracts.Models.Operations;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add configuration
builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});

ApplicationInjection.AddApplicationServices(builder.Services);
DataInjectionServices.AddDataServices(builder.Services, builder.Configuration);

// Assuming services is an instance of IServiceCollection in your dependency injection configuration
builder.Services.AddSingleton<IOperationResult, OperationResult>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();