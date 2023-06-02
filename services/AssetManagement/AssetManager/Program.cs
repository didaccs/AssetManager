using AssetManager.Common.FluentValidation;
using AssetManager.Common.MediatR;
using AssetManager.Infrastructure.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add<ApiExceptionFilterAttribute>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add SQL Entity Framework 
builder.Services.AddDbContext<AssesmentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AssetsConnection")));

// Add Fluent Validation
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ApplyDbMigrations();
app.SeedDatabaseInitialization();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
