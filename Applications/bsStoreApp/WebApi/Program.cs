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
//bunun verdi�im zeman IOC(�nversion of Control)   ye ' DbContext tan�m�n� yapm�� oluyorum.
/* Ne demek ?  bir injectiion yapt���m�z zaman dbcontexte ihtiya� duyduu�umuz zaman yani bunun somut haline ula�mam�za izin verecek
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
� Connection String
� Migrations
. Type Configuration
. Inversion of Control

� API Testi
 */
