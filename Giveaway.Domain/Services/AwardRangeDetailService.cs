using Giveaway.Domain.Entities;
using Giveaway.Domain.Ports;

namespace Giveaway.Domain.Services
{
    [DomainService]
    public class AwardRangeDetailService
    {
        private readonly IGenericRepository<AwardRangeDetail> repository;
        private readonly UserService userService;
        private readonly AwardRangeService awardRangeService;

        public AwardRangeDetailService(
            IGenericRepository<AwardRangeDetail> repository,
            UserService userService,
            AwardRangeService awardRangeService
        )
        {
            this.repository = repository;
            this.userService = userService;
            this.awardRangeService = awardRangeService;
        }

        public async Task<string> AssignedNumberToUserAsync(
            Guid userId,
            Guid awardId
        )
        {
            User user = await userService.GetUserByIdAsync(userId);
            AwardRange awardRange = await awardRangeService.GetAwardRangeByAwardIdAsync(awardId);
            AwardRangeDetail awardRangeDetail = await GetAwardRangeDetailByUserId(user.Id);

            if (awardRangeDetail != null)
            {
                return awardRangeDetail.AssignedNumber.ToString("D5");
            }

            int assignedNumber = await GetMaxNumberAsync(awardRange.Id);

            AwardRangeDetail awardRangeDetailSave = new(awardRange.Id, user.Id);
            awardRangeDetailSave.SetAssignedNumber(assignedNumber, awardRange);

            await repository.AddAsync(awardRangeDetailSave);

            return awardRangeDetailSave.AssignedNumber.ToString("D5");
        }

        public async Task<AwardRangeDetail> GetAwardRangeDetailByUserId(Guid userId)
        {
            return await repository.GetByAlternateKeyAsync(
                awardRangeDetail => awardRangeDetail.UserId == userId
            );
        }

        public async Task<int> GetMaxNumberAsync(Guid awardRangeId)
        {
            IEnumerable<AwardRangeDetail> details = await repository.GetAsync(detail => detail.AwardRangeId == awardRangeId);

            if (!details.Any())
            {
                return 1;
            }

            return details.Max(detail => detail.AssignedNumber) + 1;
        }
    }
}
