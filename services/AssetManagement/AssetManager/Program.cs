using AssetManager.Common.FluentValidation;
using AssetManager.Common.MediatR;
using AssetManager.Infrastructure.Persistence;
using AssetManager.Common.AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using AssetManager.WebApi.Services;

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

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

// Add AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IntegerToHashIdMemberValueResolver>();
builder.Services.AddTransient<HashIdToIntegerValueResolver>();

// Identity DDBB
builder.Services
    .AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AssesmentDbContext>();

builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

// Authentication & Authorization
builder.Services
    .AddHttpContextAccessor()
    .AddAuthorization()
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// Swagger Authentication 
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "My API",
            Version = "v1"
        });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please insert JWT with Bearer into field",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
       {
         new OpenApiSecurityScheme
         {
           Reference = new OpenApiReference
           {
             Type = ReferenceType.SecurityScheme,
             Id = "Bearer"
           }
          },
          new string[] { }
        }
      });
    });

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
