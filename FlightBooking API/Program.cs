using FlightBookAPI.DBContext;
using FlightBookAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
 
var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
builder.Services.AddDbContext<AppDBContext>(Option =>
Option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
 
builder.Services.AddScoped<IFlightRepository, FlightService>();
//builder.Services.AddScoped<IBookingRepository, BookingService>();
 
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