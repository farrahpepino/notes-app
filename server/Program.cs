using server.Data;
using server.Services;
using server.Repositories;
using server.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add services 
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<NoteService>(); 
builder.Services.AddScoped<NoteRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
// app.UseMiddleware<GlobalExceptionHandler>();
app.UseCors("AllowAll"); // Enable CORS
app.MapControllers(); // Map controllers to handle requests
app.Run(); // Start the application
