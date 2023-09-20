using eCommerce.Products.Core.Products.Catalag.Repositories;
using eCommerce.Products.Core.Products.Catalag.Services;
using eCommerce.Products.Core.Products.Catalag.Services.Impl;
using eCommerce.Products.Infrastructure;
using eCommerce.Products.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ProductsDBContext>(m =>
                m.UseSqlServer(builder.Configuration.GetConnectionString("productsDB")), // TODO: separate name from connection string.
            ServiceLifetime.Singleton);

builder.Services.AddAutoMapper(typeof(Program));

// services
// ID
builder.Services.AddScoped<IProductDeviceRepository, ProductDeviceRepository>();
builder.Services.AddScoped<IProductDeviceService, ProductDeviceService>();

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
