using Microsoft.EntityFrameworkCore;
using projeto01.Data;

var builder = WebApplication.CreateBuilder(args);

// Adiciona controllers
builder.Services.AddControllers();

// 🔥 SWAGGER (interface visual da API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexão com o banco MySQL
var connectionstring = builder.Configuration.GetConnectionString("AppDbConnectionString");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring)));

var app = builder.Build();

// ⚙️ Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();      // Gera o JSON da API
    app.UseSwaggerUI();    // Abre a interface web
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
