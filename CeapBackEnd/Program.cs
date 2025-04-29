using CeapBackEnd.Context;
using CeapBackEnd.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddDbContext<CeapDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", 
            policy => policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
        );
});

builder.Services.AddScoped<AlunoService>();

var app = builder.Build();

app.MapControllers();
app.UseCors("CorsPolicy");


app.Run();
