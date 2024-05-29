using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MindMuse.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MindMuse.Application.Filters;
using MindMuse.Application;
using MindMuse.Data.Contracts.Interfaces;
using System.Text;

// Pjesa tjetër e konfigurimeve ekzistuese
var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
builder.Configuration.AddJsonFile("appsettings.json");

//builder.Services.AddScoped<AppointmentMongoService>();
// Shtimi i MongoDBSettings
builder.Services.Configure<MongoDBSettings>(
    configuration.GetSection(nameof(MongoDBSettings)));

builder.Services.AddSingleton<IMongoDBSettings>(sp =>
    sp.GetRequiredService<IOptions<MongoDBSettings>>().Value);

builder.Services.AddSingleton<MongoClient>(s =>
    new MongoClient(configuration.GetValue<string>("MongoDBSettings:ConnectionString")));

builder.Services.AddScoped(s =>
    s.GetRequiredService<MongoClient>().GetDatabase(configuration.GetValue<string>("MongoDBSettings:DatabaseName")));




// Pjesa tjetër e konfigurimeve ekzistuese
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});

builder.Services.AddLogging(builder =>
{
    builder.SetMinimumLevel(LogLevel.Information);
    builder.AddConsole();
});

ApplicationInjection.AddApplicationServices(builder.Services, builder.Configuration);
DataInjectionServices.AddDataServices(builder.Services, builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
        policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3001");
    });
});

// Add authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]))
        };
    });

// Other service registrations (Application services, Data services, Swagger, etc.)
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });

    // Add customization for DateOnly serialization
    c.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name v1"));
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
