using Vindi.Cash.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddDatabaseConfiguration();

builder.Services.AddDependencyInjectionConfiguration();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.AddMigrationsConfiguration();

app.AddSwaggerConfiguration();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
