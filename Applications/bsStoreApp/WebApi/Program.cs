using Microsoft.EntityFrameworkCore;
using WebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));
//bunun verdiðim zeman IOC(ýnversion of Control)   ye ' DbContext tanýmýný yapmýþ oluyorum.
/* Ne demek ?  bir injectiion yaptýðýmýz zaman dbcontexte ihtiyaç duyduuðumuz zaman yani bunun somut haline ulaþmamýza izin verecek
*/

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

/*
  . Entities / Models
. Repository Context
· Connection String
· Migrations
. Type Configuration
. Inversion of Control

· API Testi
 */
