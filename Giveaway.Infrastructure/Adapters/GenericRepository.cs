using Giveaway.Domain.Ports;
using Giveaway.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Giveaway.Infrastructure.Adapters
{
    public class GenericRepository<E> : IGenericRepository<E>
        where E : Domain.Entities.Base.DomainEntity
    {
        private readonly PersistenceContext context;

        public GenericRepository(PersistenceContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<E> AddAsync(E entity)
        {
            context.Set<E>().Add(entity);
            await CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<E>> GetAsync(Expression<Func<E, bool>>? filter = null, bool isTracking = false)
        {
            IQueryable<E> query = context.Set<E>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return (!isTracking) ? await query.AsNoTracking().ToListAsync() : await query.ToListAsync();
        }

        public async Task<E> GetByAlternateKeyAsync(Expression<Func<E, bool>> alternateKey)
        {
            var entity = context.Set<E>().AsNoTracking();

            return await entity.FirstOrDefaultAsync(alternateKey).ConfigureAwait(false);
        }

        public async Task<E> UpdateAsync(E entity)
        {
            context.Set<E>().Update(entity);
            await CommitAsync();
            return entity;
        }

        public async Task CommitAsync()
        {
            context.ChangeTracker.DetectChanges();

            await context.CommitAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            context.Dispose();
        }
    }
}
