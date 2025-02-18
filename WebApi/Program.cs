using WebApi.Conexion;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//configuracion para implementar jwt
builder.Configuration.AddJsonFile("appsettings.json");



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<ISesionServicio, SesionServicio>();
builder.Services.AddSingleton(new UtileriasBD());

//creacion de la politica de uso del api con el cliente
builder.Services.AddCors(optiones => {
    optiones.AddPolicy("nuevapolitica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("nuevapolitica");

app.MapControllers();

app.Run();