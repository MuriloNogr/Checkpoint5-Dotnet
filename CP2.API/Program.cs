using CP2.Application.Services;
using CP2.Domain.Interfaces;
using CP2.Data.AppData;
using CP2.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicione o contexto do banco de dados
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Registre as interfaces e suas implementações
builder.Services.AddTransient<IFornecedorApplicationService, FornecedorApplicationService>();
builder.Services.AddTransient<IFornecedorRepository, FornecedorRepository>();

builder.Services.AddTransient<IVendedorApplicationService, VendedorApplicationService>();
builder.Services.AddTransient<IVendedorRepository, VendedorRepository>();

// Adicione outros serviços, como controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
