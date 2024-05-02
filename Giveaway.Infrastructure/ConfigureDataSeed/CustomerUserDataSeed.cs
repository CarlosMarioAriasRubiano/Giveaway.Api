using Giveaway.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giveaway.Infrastructure.ConfigureDataSeed
{
    public class CustomerUserDataSeed : IEntityTypeConfiguration<CustomerUser>
    {
        public void Configure(EntityTypeBuilder<CustomerUser> builder)
        {
            builder.HasData(
                new()
                {
                    Id = new("c791ff70-76bc-4bee-b331-2900580d765d"),
                    CustomerId = new("513038a6-4719-46fd-b762-dfa4436c82e5"),
                    UserId = new("2c5868b7-ea20-471d-9659-f562d6cde3ff")
                },
                new()
                {
                    Id = new("2310e7f3-960e-47f3-8316-c60e3c78f785"),
                    CustomerId = new("4c6cdaae-4e12-4f18-afb1-58ed33513284"),
                    UserId = new("2c5868b7-ea20-471d-9659-f562d6cde3ff")
                },
                new()
                {
                    Id = new("3a5b99ab-0489-4324-989e-a193e79a0c00"),
                    CustomerId = new("4c6cdaae-4e12-4f18-afb1-58ed33513284"),
                    UserId = new("5ae5a174-98cc-4ed5-9dca-39c8b8d2bc3c")
                }
            );
        }
    }
}
