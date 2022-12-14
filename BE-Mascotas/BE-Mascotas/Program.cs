using BE_Mascotas.Models;
using BE_Mascotas.Models.Repository;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//cors
builder.Services.AddCors(options => options.AddPolicy("AllowWebapp",
                      builder => builder.AllowCredentials()
                                       .AllowAnyHeader()
                                       .AllowAnyMethod()));
//agregamos context
builder.Services.AddDbContext<AplicationDbContext>(options =>
{
    //creamos una variable para poder ingresar nombrede nuestra conexion a sql
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion"));
});


//Automapper
builder.Services.AddAutoMapper(typeof(Program));
//Add Services utilizar inyeccion de dependencias
builder.Services.AddScoped<IMascotaRepository, MascotaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//cors
app.UseCors("AllowWebapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

