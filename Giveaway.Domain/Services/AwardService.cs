using Giveaway.Domain.Entities;
using Giveaway.Domain.Ports;

namespace Giveaway.Domain.Services
{
    [DomainService]
    public class AwardService
    {
        private readonly IAdoRepository<Award> adoRepository;
        private readonly CustomerService customerService;
        private readonly AwardRangeService awardRangeService;

        public AwardService(
            IAdoRepository<Award> adoRepository,
            CustomerService customerService,
            AwardRangeService awardRangeService
        )
        {
            this.adoRepository = adoRepository;
            this.customerService = customerService;
            this.awardRangeService = awardRangeService;
        }

        public async Task CreateAwardAsync(Award award)
        {
            _ = await customerService.GetCustomerByIdAsync(award.CustomerId);

            Guid awardId = await adoRepository.AddAsync(award);

            AwardRange awardRange = new(awardId);

            await awardRangeService.CreateAwardRange(awardRange);
        }
    }
}
