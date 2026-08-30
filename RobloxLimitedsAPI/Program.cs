using Microsoft.EntityFrameworkCore;
using RobloxLimitedsAPI.Data;
using RobloxLimitedsAPI.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Tells the app: Whenever a controller asks for IRobloxLimitedsService, hand it RobloxLimitedsService automatically. Reset it for every new request.
builder.Services.AddScoped<IRobloxLimitedsService, RobloxLimitedsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
     app.MapOpenApi();
     app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
