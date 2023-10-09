//---Agrego middlewares al pipeline
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//---Construyo el objeto Applicacion
var app = builder.Build();

//---Determino los elementos que se usarán en el pipe de la aplicacion
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


//---Aqui ejecuto efectivamente la Aplicacion web como fue seteada
app.Run();
