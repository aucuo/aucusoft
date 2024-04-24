using api;
using api.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173")  // Add the client's URL
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 21)));
    options.UseLazyLoadingProxies(false);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.Write("\n[author]: ");
Console.ForegroundColor = ConsoleColor.Gray;
Console.Write("Prod by Jahor Šykaviec. All rights are not reserved. Free for use. gOoD lUcK =)\n\n");
app.Run();


