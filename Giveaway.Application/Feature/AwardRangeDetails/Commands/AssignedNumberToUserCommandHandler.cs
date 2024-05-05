using AutoMapper;
using Giveaway.Application.DTOs;
using Giveaway.Domain.Services;
using MediatR;

namespace Giveaway.Application.Feature.AwardRangeDetails.Commands
{
    public class AssignedNumberToUserCommandHandler : IRequestHandler<AssignedNumberToUserCommand, AwardRangeDetailDto>
    {
        private readonly IMapper mapper;
        private readonly AwardRangeDetailService service;

        public AssignedNumberToUserCommandHandler(
            IMapper mapper,
            AwardRangeDetailService service
        )
        {
            this.mapper = mapper;
            this.service = service;
        }

        public async Task<AwardRangeDetailDto> Handle(AssignedNumberToUserCommand command, CancellationToken cancellationToken)
        {
            return mapper.Map<AwardRangeDetailDto>(
                await service.AssignedNumberToUserAsync(
                    command.UserId,
                    command.AwardId
                )
            );
        }
    }
}
