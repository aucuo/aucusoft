using Pomelo.EntityFrameworkCore.MySql;
using api.Context;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 21))));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.Write("\n[author]: ");
Console.ForegroundColor = ConsoleColor.Gray;
Console.Write("Prod by Jahor Šykaviec. All rights are not reserved. Free for use. gOoD lUcK =)\n\n");
app.Run();


