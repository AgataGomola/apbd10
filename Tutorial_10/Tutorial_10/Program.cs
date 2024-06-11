using Microsoft.EntityFrameworkCore;
using Tutorial_10.Contexts;
using Tutorial_10.Models;
using Tutorial_10.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<DataBaseContext>(
    options => options.UseSqlServer("Name=ConnectionStrings:Default"));
 builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
// builder.Services.AddScoped<ITripService, TripService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();