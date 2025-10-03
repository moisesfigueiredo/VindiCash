using Vindi.Cash.Api.Domain.Entities;

namespace Vindi.Cash.Api.Domain.Abstractions
{
    public interface IContaRepository : IBaseRepository, IRepository<Conta>
    {
        Task<List<Conta>> GetAllAsync(string? name, string? document);
    }
}
