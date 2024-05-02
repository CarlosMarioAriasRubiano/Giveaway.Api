using Giveaway.Domain.Entities.Base;

namespace Giveaway.Domain.Entities
{
    public class AwardRange : EntityBase<Guid>
    {
        public Guid AwardId { get; set; }
        public int InitialRange { get; set; }
        public int EndRange { get; set; }

        public virtual Award Award { get; set; } = default!;
        public virtual IEnumerable<AwardRangeDetail> AwardRangeDetails { get; set; } = default!;

        public AwardRange() { }

        public AwardRange(
            Guid awardId
        )
        {
            AwardId = awardId;
            InitialRange = 1;
            EndRange = 99999;
        }
    }
}
