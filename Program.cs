using VacinaWeb.Repository;
using VacinaWeb.Repository.Interfaces;
using VacinaWeb.Services;
using VacinaWeb.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPostoService, PostoService>();
builder.Services.AddScoped<IPostoRepository, PostoRepository>();
builder.Services.AddScoped<IVacinaService, VacinaService>();
builder.Services.AddScoped<IVacinaRepository, VacinaRepository>();
builder.Services.AddScoped<IPostoVacinaService, PostoVacinaService>();
builder.Services.AddScoped<IPostoVacinaRepository, PostoVacinaRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
