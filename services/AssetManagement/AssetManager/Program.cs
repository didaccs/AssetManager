using AssetManager.Application.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using AssetManager.Application;
using AssetManager.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebApi();
builder.Services.AddApplicationCore();
builder.Services.AddPersistence(builder.Configuration.GetConnectionString("AssetsConnection"));
builder.Services.AddSecurity(builder.Configuration);

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
