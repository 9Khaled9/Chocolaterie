using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Chocolaterie.Data;
using Microsoft.AspNetCore.Hosting;
using Chocolaterie.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ChocolaterieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ChocolaterieContext") ?? throw new InvalidOperationException("Connection string 'ChocolaterieContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IChocolaterieService, ChocolaterieService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
