using EnergyComparisonTest.ExceptionHandler;
using EnergyComparisonTest.Repositories.Interfaces;
using EnergyComparisonTest.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Energy Comparison Test",
        Version = "v1",
        Description = "This API will <ul>" +
                      "<li>Manage tariff products</li>" +
                      "</ul>",
        Contact = new OpenApiContact
        {
            Name = "SYED TALHA SHAMIM",
            Email = "syedtalha30@gmail.com",
        }
    }
    );
});
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddControllers(options => options.Filters.Add(new ExceptionHandlerFilter()));
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
