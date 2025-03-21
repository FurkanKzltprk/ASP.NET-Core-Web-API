var builder = WebApplication.CreateBuilder(args);
//Service (Container) !

builder.Services.AddControllers();  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); //swager� nugetten paketini dahil etmek gerekiyor



var app = builder.Build();

if (app.Environment.IsDevelopment())
{

    app.UseSwagger();  //burada swagger kullanmas� gerekti�ini s�yledik yoksa swagger kullanmaz.
    app.UseSwaggerUI();
}


app.MapControllers(); //home ifadesi ��z�lemedi�i i�in istek tam olmad� Map Controller'� eklememiz gerekiyor yoksa olmaz.
app.Run();
