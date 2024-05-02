using Giveaway.Domain.Entities.Base;

namespace Giveaway.Domain.Entities
{
    public class CustomerUser : EntityBase<Guid>
    {
        public Guid CustomerId { get; set; }
        public Guid UserId { get; set; }

        public virtual Customer Customer { get; set; } = default!;
        public virtual User User { get; set; } = default!;
    }
}
