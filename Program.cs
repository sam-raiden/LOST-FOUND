using CampusLostFound.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// -------------------- SERVICES --------------------

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database (PostgreSQL / Neon)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// ✅ CORS (FIXED FOR VERSEL + DEV)
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
    {
        policy
            .AllowAnyOrigin()   // 🔥 IMPORTANT
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// ✅ Bind to Railway PORT (REQUIRED)
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

var app = builder.Build();

// -------------------- PIPELINE --------------------

app.UseSwagger();
app.UseSwaggerUI();

// 🔥 CORS MUST BE BEFORE CONTROLLERS
app.UseCors("FrontendPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

