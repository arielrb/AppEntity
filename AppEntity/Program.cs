using AppEntity.Contexto;
using AppEntity.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Este metodo llama al servicio de conexion a BBDD en memoria
//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasBD"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

// Add services to the container.
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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

//Mapeos para las URL
app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");
//Este dice hola mundo
app.MapGet("/hola", () => "Hola mundo!");
//Chequeo de conexion de BBDD en memoria
app.MapGet("/bbdd", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("La base de datos está en memoria?: " + dbContext.Database.IsInMemory());
});

//Metodo get para listar la informacion de tareas
app.MapGet("/Tareas/listar", async([FromServices] TareasContext dbcontext) => {
    return Results.Ok(dbcontext.tareas.Include(p => p.categoria));
});

//Metodo Post

app.MapPost("/Tareas/Guardar", async ([FromServices] TareasContext dbcontext, [FromBody] Tarea tarea) =>
{

    await dbcontext.AddAsync(tarea);

    await dbcontext.SaveChangesAsync();

    return Results.Ok("Todo OK campeon");
});

//Metodo put
app.MapPut("/Tareas/Update/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] int id) =>
{
    var tareaActual = dbContext.tareas.Find(id);

    if(tareaActual != null)
    {

        tareaActual.IdCategoria = tarea.IdCategoria;
        tareaActual.TareaName = tarea.TareaName;
    }
    await dbContext.SaveChangesAsync();

    return Results.Ok("Todo se actualizo re manso");

});

//Metodo delete
app.MapDelete("/Tareas/Eliminar/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] int id) =>
{
    var tareaActual = dbContext.tareas.Find(id);

    if (tareaActual != null)
    {

        dbContext.Remove(tareaActual);

        await dbContext.SaveChangesAsync();
        return Results.Ok("Todo se elimino re contra manso");

    }
    else
    {
        return Results.NotFound();

    }


});


app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}