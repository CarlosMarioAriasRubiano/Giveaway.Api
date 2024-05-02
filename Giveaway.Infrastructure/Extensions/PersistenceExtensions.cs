using Giveaway.Domain.Ports;
using Giveaway.Infrastructure.Adapters;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Giveaway.Infrastructure.Extensions
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(IAdoRepository<>), typeof(AdoRepository<>));
            services.AddTransient<IDbConnection>(_ => new SqlConnection(configuration.GetConnectionString("DevConnection")));

            return services;
        }
    }
}
