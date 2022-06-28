using FluentValidation;
using FluentValidation.AspNetCore;
using Lap.Data.Repositories;
using LapAPI.Data;
using LapAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LapContext>
    (options => options.UseSqlite("Name=LapDB"));

builder.Services.AddValidatorsFromAssemblyContaining<LapInfoValidator>();
builder.Services.AddScoped<ILapRepository, LapRepository>();
builder.Services.AddScoped<ILapInfoManager, LapInfoManager>();

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
