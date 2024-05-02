using Giveaway.Domain.Ports;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace Giveaway.Infrastructure.Adapters
{
    public class AdoRepository<E> : IAdoRepository<E>
        where E : Domain.Entities.Base.DomainEntity
    {
        private readonly IDbConnection connection;

        public AdoRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<Guid> AddAsync(E entity)
        {
            Type entityType = entity.GetType();
            IEnumerable<PropertyInfo> properties = entityType.GetProperties().Where(prop => !prop.GetGetMethod()!.IsVirtual);

            List<string> fields = [];
            List<string> values = [];
            Guid newId = Guid.NewGuid();

            foreach (var property in properties)
            {
                fields.Add(property.Name);
                values.Add($"'{property.GetValue(entity)!}'");
            }

            IDbCommand command = new SqlCommand();

            command.CommandText = $"INSERT INTO {entityType.Name}(Id, {string.Join(", ", fields)}) VALUES('{newId}', {string.Join(", ", values)})";
            command.Connection = connection;

            await Task.Run(() =>
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            });

            return newId;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
