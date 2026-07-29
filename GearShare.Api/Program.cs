using GearShare.Api.Infrastructure;
using Scalar.AspNetCore;
using Serilog;

//we loggin' this
Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();


var builder = WebApplication.CreateBuilder(args);

//Yeah
builder.Host.UseSerilog();

builder.Services.AddControllers();

//Added memory caching
builder.Services.AddMemoryCache();

//Exception handler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// OpenAPI
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseSerilogRequestLogging(options =>
{
    options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";
});

//are these my endpoints
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();