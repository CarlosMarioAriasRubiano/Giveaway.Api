using Giveaway.Domain.Entities;
using Giveaway.Domain.Services;
using MediatR;

namespace Giveaway.Application.Feature.Awards.Commands
{
    public class CreateAwardCommandHandler : AsyncRequestHandler<CreateAwardCommand>
    {
        private readonly AwardService service;

        public CreateAwardCommandHandler(
            AwardService service
        )
        {
            this.service = service;
        }

        protected async override Task Handle(
            CreateAwardCommand command,
            CancellationToken cancellationToken
        )
        {
            Award award = new(command.Name, command.CustomerId);

            await service.CreateAwardAsync(award);
        }
    }
}
