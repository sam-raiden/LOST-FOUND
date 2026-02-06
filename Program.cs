using CampusLostFound.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// -------------------- SERVICES --------------------

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 🔥 CORS — OPEN (Railway-safe)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// -------------------- PIPELINE --------------------

// 🔥 VERY IMPORTANT ORDER
app.UseCors();                 // 1️⃣ FIRST
app.UseRouting();              // 2️⃣ ROUTING
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();

// 🔥 HANDLE PREFLIGHT EXPLICITLY (THIS FIXES IT)
app.MapMethods("{*path}", new[] { "OPTIONS" }, () => Results.Ok());

app.Run();
