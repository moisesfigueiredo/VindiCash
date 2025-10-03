using Vindi.Cash.Api.Domain.Abstractions;
using Vindi.Cash.Api.Domain.Entities;
using Vindi.Cash.Api.ImMemoryDatabase.Core;

namespace Vindi.Cash.Api.ImMemoryDatabase.Repositories
{
    public class LogDesativacaoRepository : Repository<LogDesativacao>, ILogDesativacaoRepository
    {
        public LogDesativacaoRepository(DataContext context) : base(context)
        {
        }
    }
}
