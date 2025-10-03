using System.Linq.Expressions;
using Vindi.Cash.Api.Domain.Entities;

namespace Vindi.Cash.Api.Domain.Abstractions
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<List<T>> GetAll();
        Task<T> GetFirst(object id);
        Task<T> GetFirst(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate);
        Task<T> Insert(T entity);
        Task<List<T>> Insert(List<T> entities);
        Task<T> Update(T entity);
        Task<List<T>> Update(List<T> entities);
        Task<T> Disable(T entity);
        Task<List<T>> Disable(List<T> entities);
        Task Delete(object id);
        Task DeleteRange(object[] ids);
    }
}