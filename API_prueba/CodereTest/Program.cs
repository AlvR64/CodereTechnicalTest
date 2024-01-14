using CodereTest.API;
using CodereTest.API.Middleware;
using CodereTest.API.Middlewares;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//InMemory DB configuration
builder.Services.AddInMemoryDbContext(builder.Configuration);

//Dependency Injection
builder.Services.AddAppServices();

//Configure Swagger
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.EnableAnnotations();

    // Swagger security definition for API key
    swagger.AddSecurityDefinition("CodereTestApiKey", new OpenApiSecurityScheme
    {
        Description = "CodereTestApiKey must appear in header",
        Type = SecuritySchemeType.ApiKey,
        Name = "CodereTestApiKey",
        In = ParameterLocation.Header,
        Scheme = "CodereTestApiKeyScheme"
    });

    // Swagger security requirement for API key
    var key = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "CodereTestApiKey"
        },
        In = ParameterLocation.Header
    };
    var requirement = new OpenApiSecurityRequirement
    {
        { key, new List<string>() }
    };
    swagger.AddSecurityRequirement(requirement);
});

var app = builder.Build();

app.UseMiddleware<ErrorMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<AuthMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
