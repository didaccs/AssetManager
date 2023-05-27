using AssetManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AssesmentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AssetsConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
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
