using EnergyTracker.Application.Commands.User;
using EnergyTracker.Application.Commands.User;
using EnergyTracker.Application.Validators;
using EnergyTracker.Domain.Interfaces;
using EnergyTracker.Infrastructure.Exporters;
using EnergyTracker.Infrastructure.Persistence;
using EnergyTracker.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EnergyTracker API", Version = "v1" });
});
builder.Services.AddDbContext<EnergyTrackerDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("EnergyTracker.Infrastructure")));

builder.Services.AddControllers()
            .AddFluentValidation(fv =>
            {
                
                fv.RegisterValidatorsFromAssemblyContaining<CreateConsumptionValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<CreateSubscriptionValidator>();
            });
// MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateUserHandler).Assembly));

// Repositories

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IConsumptionRepository, ConsumptionRepository>();
builder.Services.AddScoped<ISubscriptionRepository,SubscriptionRepository>();
builder.Services.AddScoped<IExcelExporter, ExcelExporter>();
builder.Services.AddScoped<IExcelExporterConsumption, ExcelExporterConsumption>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "EnergyTracker API v1");
});


app.UseAuthorization();

app.MapControllers();

app.Run();
