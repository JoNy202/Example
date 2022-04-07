using IntegraCompanies.WSImport;
using IntegraCompanies.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using IntegraCompanies.Shared.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.

services.AddControllers()
    .AddJsonOptions(configure => configure.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("IntegraCompanies")));

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddTransient<CompanyService>();
services.AddScoped<WSImportService>();

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
