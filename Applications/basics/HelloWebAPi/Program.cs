var builder = WebApplication.CreateBuilder(args);
//Service (Container) !

builder.Services.AddControllers();  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); //swagerý nugetten paketini dahil etmek gerekiyor



var app = builder.Build();

if (app.Environment.IsDevelopment())
{

    app.UseSwagger();  //burada swagger kullanmasý gerektiðini söyledik yoksa swagger kullanmaz.
    app.UseSwaggerUI();
}


app.MapControllers(); //home ifadesi çözülemediði için istek tam olmadý Map Controller'ý eklememiz gerekiyor yoksa olmaz.
app.Run();
