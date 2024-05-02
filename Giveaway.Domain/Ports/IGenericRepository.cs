using System.Linq.Expressions;

namespace Giveaway.Domain.Ports
{
    public interface IGenericRepository<E> : IDisposable
        where E : Entities.Base.DomainEntity
    {
        Task<IEnumerable<E>> GetAsync(Expression<Func<E, bool>>? filter = null, bool isTracking = false);
        Task<E> GetByAlternateKeyAsync(Expression<Func<E, bool>> alternateKey);
        Task<E> AddAsync(E entity);
        Task<E> UpdateAsync(E entity);
    }
}
