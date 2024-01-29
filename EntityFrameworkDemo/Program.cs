using EntityFrameworkDemo.Controllers;
using EntityFrameworkDemo.DbContexts;
using EntityFrameworkDemo.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookManagementService, BookManagementService>();

builder.Services.AddDbContext<BookDbContext>(options =>
{
    var configuration = builder.Configuration.GetSection("ConnectionStrings");
    var connectionString = configuration.GetValue<string>("BookManagementDb");
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
