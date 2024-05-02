using Giveaway.Domain.Entities.Base;

namespace Giveaway.Domain.Entities
{
    public class Award : EntityBase<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; } = default!;
        public virtual AwardRange AwardRange { get; set; } = default!;

        public Award() {}

        public Award(
            string name,
            Guid customerId
        )
        {
            Name = name;
            CustomerId = customerId;
        }
    }
}
