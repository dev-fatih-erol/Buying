using Buying.Application.Instructions.Commands;
using Buying.Application.Instructions.Queries;
using Buying.Application.Instructions.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Buying.Api.Controllers
{
    [Route("[controller]")]
    public class InstructionsController : Controller
    {
        private readonly IMediator _mediator;

        public InstructionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{instructionId:int}/Channels")]
        public async Task<IActionResult> GetInstructionChannels([FromRoute] int instructionId)
        {
            return Ok(await _mediator.Send(new GetInstructionChannelsQuery(instructionId)));
        }

        [HttpGet]
        [Route("Cancelled")]
        public async Task<IActionResult> GetCancelledInstructions(decimal? minAmount, decimal? maxAmount)
        {
            return Ok(await _mediator.Send(new GetCancelledInstructionsQuery(minAmount, maxAmount)));
        }

        [HttpGet]
        [Route("Active")]
        public async Task<IActionResult> GetActiveInstruction()
        {
            return Ok(await _mediator.Send(new GetActiveInstructionQuery()));
        }

        [HttpPut]
        [Route("Cancel")]
        public async Task<IActionResult> Cancel()
        {
            await _mediator.Send(new CancelInstructionCommand());

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInstructionRequest request)
        {
            await _mediator.Send(new CreateInstructionCommand(
                request.Amount,
                request.ExecutionDay,
                request.ChannelIds));

            return Ok();
        }
    }
}