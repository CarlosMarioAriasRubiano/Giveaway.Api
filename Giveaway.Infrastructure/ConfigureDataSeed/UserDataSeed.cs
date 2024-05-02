using Giveaway.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giveaway.Infrastructure.ConfigureDataSeed
{
    public class UserDataSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new()
                {
                    Id = new("2c5868b7-ea20-471d-9659-f562d6cde3ff"),
                    Name = "Carlos Mario Arias",
                    Identification = "33333"
                },
                new()
                {
                    Id = new("5ae5a174-98cc-4ed5-9dca-39c8b8d2bc3c"),
                    Name = "Lina María González",
                    Identification = "55555"
                }
            );
        }
    }
}
