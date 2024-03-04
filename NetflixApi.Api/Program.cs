using Microsoft.EntityFrameworkCore.Infrastructure;
using NetflixApi.Api.Models;
using NetflixApi.Application;
using NetflixApi.Infrastructure;
using Serilog;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var appState = new ApplicationState();
appState.BaseUrl = builder.Configuration["BaseUrl"]!;
builder.Services.AddSingleton(appState);

builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.WithOrigins("*")
                                                .AllowAnyHeader()
                                                .AllowAnyMethod()
                                                .SetPreflightMaxAge(TimeSpan.FromHours(1)));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("Open");
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbcontext = services.GetRequiredService<ApplicationDbContext>();

        dbcontext.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        // Handle exceptions if necessary
        Console.WriteLine(ex.Message);
    }
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program();