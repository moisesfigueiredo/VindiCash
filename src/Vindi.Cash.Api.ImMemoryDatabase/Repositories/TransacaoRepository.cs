using Vindi.Cash.Api.Domain.Abstractions;
using Vindi.Cash.Api.Domain.Entities;
using Vindi.Cash.Api.ImMemoryDatabase.Core;

namespace Vindi.Cash.Api.ImMemoryDatabase.Repositories
{
    public class TransacaoRepository : Repository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(DataContext context) : base(context)
        {
        }
    }
}
