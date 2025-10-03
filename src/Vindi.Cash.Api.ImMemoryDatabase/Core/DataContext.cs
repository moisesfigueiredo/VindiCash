using Microsoft.EntityFrameworkCore;
using Vindi.Cash.Api.Domain.Entities;

namespace Vindi.Cash.Api.ImMemoryDatabase.Core
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Conta> Accounts { get; set; }
        public DbSet<Transacao> Transactions { get; set; }
        public DbSet<LogDesativacao> DeactivationLogs { get; set; }
    }
}
