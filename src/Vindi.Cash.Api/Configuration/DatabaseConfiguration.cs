using Microsoft.EntityFrameworkCore;
using Vindi.Cash.Api.Domain.Entities;
using Vindi.Cash.Api.ImMemoryDatabase.Core;

namespace Vindi.Cash.Api.Configuration
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this WebApplicationBuilder builder)
        {
            //Configuração InMemoryDatabase
            builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("VindiCashDb"));

        }

        public static void AddMigrationsConfiguration(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<DataContext>();
                if (!ctx.Accounts.Any())
                {
                    ctx.Accounts.Add(new Conta { Nome = "Conta Inicial 1", Documento = "00000000000", Saldo = 1000m, Ativa = true, DataAbertura = DateTime.UtcNow });
                    ctx.Accounts.Add(new Conta { Nome = "Conta Inicial 2", Documento = "11111111111", Saldo = 1000m, Ativa = true, DataAbertura = DateTime.UtcNow });
                    ctx.SaveChanges();
                }
            }
        }
    }
}
