using Giveaway.Domain.Entities;
using Giveaway.Infrastructure.ConfigureDataSeed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Giveaway.Infrastructure.Context
{
    public class PersistenceContext : DbContext
    {
        private readonly IConfiguration config;

        public PersistenceContext(DbContextOptions<PersistenceContext> options, IConfiguration config)
            : base(options)
        {
            this.config = config;
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(config.GetConnectionString("DevConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }

            modelBuilder.Entity<Award>();
            modelBuilder.Entity<AwardRange>();
            modelBuilder.Entity<AwardRangeDetail>();
            modelBuilder.Entity<Customer>();
            modelBuilder.Entity<CustomerUser>();
            modelBuilder.Entity<User>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerDataSeed());
            modelBuilder.ApplyConfiguration(new UserDataSeed());
            modelBuilder.ApplyConfiguration(new CustomerUserDataSeed());
        }
    }
}
