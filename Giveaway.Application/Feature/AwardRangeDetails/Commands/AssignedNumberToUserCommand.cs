using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Giveaway.Application.Feature.AwardRangeDetails.Commands
{
    public record AssignedNumberToUserCommand(
        [Required] Guid UserId,
        [Required] Guid AwardId
    ) : IRequest<string>;
}
