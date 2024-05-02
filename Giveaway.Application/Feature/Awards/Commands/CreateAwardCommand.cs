using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Giveaway.Application.Feature.Awards.Commands
{
    public record CreateAwardCommand(
        [Required] string Name,
        [Required] Guid CustomerId
    ) : IRequest;
}
