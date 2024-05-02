using Giveaway.Domain.Entities.Base;

namespace Giveaway.Domain.Entities
{
    public class User : EntityBase<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public virtual IEnumerable<CustomerUser> CustomersUsers { get; set; } = default!;
        public virtual IEnumerable<AwardRangeDetail> AwardRangeDetails { get; set; } = default!;
    }
}
