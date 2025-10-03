using Vindi.Cash.Api.Domain.Entities;

namespace Vindi.Cash.Api.Domain.Abstractions
{
    public interface ITransacaoRepository : IBaseRepository, IRepository<Transacao>
    {
    }
}
