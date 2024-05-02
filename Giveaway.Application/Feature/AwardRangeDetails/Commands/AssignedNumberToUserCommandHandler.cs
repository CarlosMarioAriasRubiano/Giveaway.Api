using Giveaway.Domain.Services;
using MediatR;

namespace Giveaway.Application.Feature.AwardRangeDetails.Commands
{
    public class AssignedNumberToUserCommandHandler : IRequestHandler<AssignedNumberToUserCommand, string>
    {
        private readonly AwardRangeDetailService service;

        public AssignedNumberToUserCommandHandler(AwardRangeDetailService service)
        {
            this.service = service;
        }

        public async Task<string> Handle(AssignedNumberToUserCommand command, CancellationToken cancellationToken)
        {
            return await service.AssignedNumberToUserAsync(
                command.UserId,
                command.AwardId
            );
        }
    }
}
