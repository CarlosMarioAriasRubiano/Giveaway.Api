namespace Giveaway.Domain.Ports
{
    public interface IAdoRepository<E> : IDisposable
        where E : Entities.Base.DomainEntity
    {
        Task<Guid> AddAsync(E entity);
    }
}
