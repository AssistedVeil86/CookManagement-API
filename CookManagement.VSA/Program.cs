using CookManagement.VSA.Features.Authentication;
using CookManagement.VSA.Features.Inventory;
using CookManagement.VSA.Features.Movements;
using CookManagement.VSA.Features.Users;
using CookManagement.VSA.Infrastructure.Auth;
using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.Extensions;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();

//Add Database, Jwt Config, and CORS
builder.Services.AddDatabase(builder.Configuration);
builder.Services.ConfigureJwtAuth(builder.Configuration);
builder.Services.ConfigureCors();

//Register Services and Validators
builder.Services.RegisterServices();
builder.Services.RegisterValidators();

//Register Handlers
builder.Services.RegisterAuthHandlers();
builder.Services.RegisterInventoryHandlers();
builder.Services.RegisterMovementsHandlers();
builder.Services.RegisterUserHandlers();

//Configure Serilog as Provider
builder.Host.UseSerilog((context, configuration)
    => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("scalar", options => options.Layout = ScalarLayout.Classic);
}

app.UseHttpsRedirection();

//Register Serilog HTTP Middleware
app.UseSerilogRequestLogging();

//Use Cors Policy
app.UseCors("AllowReact");

app.UseAuthentication();
app.UseAuthorization();

//Mapping Endpoints
app.MapAuthEndpoints();
app.MapInventoryEndpoints();
app.MapMovementsEndpoints();
app.MapUserEndpoints();

app.Run();