using Giveaway.Domain.Entities.Base;
using Giveaway.Domain.Exceptions;

namespace Giveaway.Domain.Entities
{
    public class AwardRangeDetail : EntityBase<Guid>
    {
        public Guid AwardRangeId { get; set; }
        public Guid UserId { get; set; }
        public int AssignedNumber { get; set; }

        public virtual AwardRange AwardRange { get; set; } = default!;
        public virtual User User { get; set; } = default!;

        public AwardRangeDetail() { }

        public AwardRangeDetail(
            Guid awardRangeId,
            Guid userId
        )
        {
            AwardRangeId = awardRangeId;
            UserId = userId;
        }

        public void SetAssignedNumber(int assignedNumber, AwardRange awardRange)
        {
            string formattedNumber = assignedNumber.ToString("D5");

            ValidateRangeNumber(assignedNumber, awardRange);

            if (!ValidateConsecutiveNumber(formattedNumber))
            {
                assignedNumber += 1;
                SetAssignedNumber(assignedNumber, awardRange);
            }
            else
            {
                AssignedNumber = assignedNumber;
            }
        }

        private static bool ValidateConsecutiveNumber(string formattedNumber)
        {
            for (int i = 0; i <= formattedNumber.Length - 3; i++)
            {
                if (formattedNumber[i] == formattedNumber[i + 1]
                    && formattedNumber[i] == formattedNumber[i + 2]
                )
                {
                    return false;
                }
            }

            return true;
        }

        private static void ValidateRangeNumber(int assignedNumber, AwardRange awardRange)
        {
            if (!(assignedNumber >= awardRange.InitialRange && assignedNumber <= awardRange.EndRange))
            {
                throw new ValidatorException(MessagesExceptions.OutdatedValue);
            }
        }
    }
}
