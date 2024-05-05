using AutoMapper;
using Giveaway.Application.DTOs;
using Giveaway.Domain.Entities;
using Giveaway.Domain.Services;
using MediatR;

namespace Giveaway.Application.Feature.Awards.Commands
{
    public class CreateAwardCommandHandler : IRequestHandler<CreateAwardCommand, AwardDto>
    {
        private readonly IMapper mapper;
        private readonly AwardService service;

        public CreateAwardCommandHandler(
            IMapper mapper,
            AwardService service
        )
        {
            this.mapper = mapper;
            this.service = service;
        }

        public async Task<AwardDto> Handle(
            CreateAwardCommand command,
            CancellationToken cancellationToken
        )
        {
            Award award = new(command.Name, command.CustomerId);

            return mapper.Map<AwardDto>(
                await service.CreateAwardAsync(award)
            );
        }
    }
}
