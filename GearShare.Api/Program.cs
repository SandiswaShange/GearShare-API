using GearShare.Api.Infrastructure;
using Scalar.AspNetCore;
using Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GearShare.Api.Data;
using Microsoft.EntityFrameworkCore;

//we loggin' this
Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();


var builder = WebApplication.CreateBuilder(args);

//Yeah
builder.Host.UseSerilog();

builder.Services.AddControllers();

//Part D
var jwt = builder.Configuration.GetSection("Jwt");

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,

            ValidIssuer = jwt["Issuer"],
            ValidAudience = jwt["Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwt["Key"]!))
        };
    });

builder.Services.AddAuthorization();

//Added memory caching
builder.Services.AddMemoryCache();

//Exception handler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

//DbContext
builder.Services.AddDbContext<GearShareDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

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

//add authentication
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();