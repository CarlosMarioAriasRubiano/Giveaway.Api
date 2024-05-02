using Giveaway.Domain.Entities.Base;

namespace Giveaway.Domain.Entities
{
    public class Customer : EntityBase<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public virtual IEnumerable<CustomerUser> CustomersUsers { get; set; } = default!;
    }
}
