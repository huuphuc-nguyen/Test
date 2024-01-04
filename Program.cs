using Microsoft.EntityFrameworkCore;
using PictureSocialMedia.Infrastructure;
using System.Diagnostics.CodeAnalysis;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Load Environment Variables
DotNetEnv.Env.Load();

// Connect SQL
builder.Services.AddDbContext<ApplicationDBContext>(x => x.UseSqlServer(Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTIONSTRING")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();