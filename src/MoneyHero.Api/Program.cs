using Microsoft.EntityFrameworkCore;
using MoneyHero.Data;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddDbContext<MoneyHeroContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("MoneyHeroDb"));
});

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
