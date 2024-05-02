using Giveaway.Domain.Entities;
using Giveaway.Domain.Exceptions;
using Giveaway.Domain.Ports;

namespace Giveaway.Domain.Services
{
    [DomainService]
    public class AwardRangeService
    {
        private readonly IGenericRepository<AwardRange> repository;
        private readonly IAdoRepository<AwardRange> adoRepository;

        public AwardRangeService(
            IGenericRepository<AwardRange> repository,
            IAdoRepository<AwardRange> adoRepository
        )
        {
            this.repository = repository;
            this.adoRepository = adoRepository;
        }

        public async Task<AwardRange> GetAwardRangeByAwardIdAsync(Guid awardId)
        {
            AwardRange awardRange = await repository.GetByAlternateKeyAsync(
                awardRange => awardRange.AwardId == awardId
            ) ?? throw new ValidatorException(MessagesExceptions.AwardNotExists);

            return awardRange;
        }

        public async Task CreateAwardRange(AwardRange awardRange)
        {
            await adoRepository.AddAsync(awardRange);
        }
    }
}
