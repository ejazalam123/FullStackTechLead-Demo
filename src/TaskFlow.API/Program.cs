//using TaskFlow.Domain.Services;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

//builder.Services.AddOpenApi();
//builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<ITaskService, TaskService>();

//var app = builder.Build();
//// Move these two lines so they run regardless of the environment


//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//    app.UseSwagger();
//    app.UseSwaggerUI();
//    // Other development-only middleware...
//}
//// Configure the HTTP request pipeline.


//app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast");

//app.Run();

//record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}



using TaskFlow.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container.
builder.Services.AddOpenApi(); // This is the new .NET 9+ way
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

// --- ADD THESE TWO LINES TO FIX THE ERROR ---
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITaskService, TaskService>();

// --------------------------------------------

var app = builder.Build();
app.MapControllers();

// 2. Configure the HTTP request pipeline.
// These must be outside the 'if' block for now so you can see them!
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    // This tells Swagger where to find the JSON definition
    options.SwaggerEndpoint("/openapi/v1.json", "v1");
});

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // This generates the actual JSON file
}

app.UseHttpsRedirection();

// Your existing Weather Logic
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}





