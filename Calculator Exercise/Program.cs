using Application.Services;
using Domain.Interfaces;
using Domain.Queries;
using FluentValidation;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Net;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();
services.AddScoped<IValidator<EquationQuery>, EquationQueryValidator>();

services.AddEndpointsApiExplorer();

services.AddScoped<ICalculationService, Calculator>();


services.AddOpenApiDocument(configure =>
{
    configure.Title = "Calculator API";
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseOpenApi();

app.UseSwaggerUi3(settings =>
{
    settings.Path = "/api";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
