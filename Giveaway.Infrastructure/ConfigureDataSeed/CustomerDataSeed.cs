using Giveaway.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giveaway.Infrastructure.ConfigureDataSeed
{
    public class CustomerDataSeed : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new()
                {
                    Id = new("513038a6-4719-46fd-b762-dfa4436c82e5"),
                    Name = "Sistema POS",
                    Identification = "123456",
                    Address = "Calle 46"
                },
                new()
                {
                    Id = new("4c6cdaae-4e12-4f18-afb1-58ed33513284"),
                    Name = "Sistema ERP",
                    Identification = "654321",
                    Address = "Carrera 15"
                }
            );
        }
    }
}
