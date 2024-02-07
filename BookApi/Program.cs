using BookApi.DBContext;
using BookApi.DBContext.Repository;
using BookApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DB Context 
builder.Services.AddDbContext<BookContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("MyContextConnection")));

//Repository
builder.Services.AddTransient<IRepository<Book>, Repository<Book>>();

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
