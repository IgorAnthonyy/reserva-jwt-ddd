using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Reservas.Application.Services;
using Reservas.Domain.Interfaces;
using Reservas.Infrastructure.Auth;
using Reservas.Infrastructure.Data;
using Reservas.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 🔐 Configuração de JWT
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

// Obter as configurações de JWT de forma centralizada
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
if (jwtSettings == null || string.IsNullOrEmpty(jwtSettings.Key))
{
    throw new InvalidOperationException("As configurações de JWT não estão corretas.");
}

var key = Encoding.UTF8.GetBytes(jwtSettings.Key);

// 🔐 Configuração de Autenticação e Autorização JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization();

// 📦 Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🧠 Injeção de dependência (DDD)
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<UsuarioService>();

builder.Services.AddScoped<IBuffetRepository, BuffetRepository>();
builder.Services.AddScoped<BuffetService>();

builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<ReservaService>();

builder.Services.AddScoped<TokenService>();

// 🗺️ Configuração de Mapster para mapeamentos
UsuarioProfile.ConfigureMappings();
ReservaProfile.ConfigureMappings();
BuffetProfile.ConfigureMappings();

// 🗄️ Banco de dados
builder.Services.AddDbContext<ReservaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 🧪 Swagger apenas em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🛠️ Executar migrações ao iniciar o app
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ReservaDbContext>();
    context.Database.Migrate();
}

// 🔐 Middleware de autenticação/autorizações
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// 🚀 Mapear endpoints
app.MapControllers();

app.Run();
