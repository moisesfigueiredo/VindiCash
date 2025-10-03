using Microsoft.EntityFrameworkCore;
using Vindi.Cash.Api.Domain.Abstractions;
using Vindi.Cash.Api.Domain.Entities;
using Vindi.Cash.Api.ImMemoryDatabase.Core;

namespace Vindi.Cash.Api.ImMemoryDatabase.Repositories
{
    public class ContaRepository : Repository<Conta>, IContaRepository
    {
        public ContaRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<Conta>> GetAllAsync(string? name, string? document)
        {
            var query = _context.Accounts.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(a => a.Nome.Contains(name));

            if (!string.IsNullOrWhiteSpace(document))
                query = query.Where(a => a.Documento.Contains(document));

            return await query.ToListAsync();
        }
    }
}
