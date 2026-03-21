using Microsoft.EntityFrameworkCore;
using SistemaPropostas.API.Data;
using SistemaPropostas.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Swagger padrão
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<ClienteService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<SistemaPropostas.API.Middlewares.ExceptionMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
