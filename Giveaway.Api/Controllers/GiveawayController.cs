using Giveaway.Api.Authentication;
using Giveaway.Application.DTOs;
using Giveaway.Application.Feature.AwardRangeDetails.Commands;
using Giveaway.Application.Feature.Awards.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Giveaway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiKeyAuthFilter]
    [ApiController]
    public class GiveawayController : ControllerBase
    {
        private readonly IMediator mediator;

        public GiveawayController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("assignedNumberToUser")]
        public async Task<AwardRangeDetailDto> AssignedNumberToUserAsync(
            AssignedNumberToUserCommand command
        )
        {
            return await mediator.Send(command);
        }

        [HttpPost("createAward")]
        public async Task<AwardDto> CreateAwardAsync(
            CreateAwardCommand command
        )
        {
            return await mediator.Send(command);
        }
    }
}
