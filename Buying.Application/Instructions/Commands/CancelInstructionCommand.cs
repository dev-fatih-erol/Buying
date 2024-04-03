using MediatR;

namespace Buying.Application.Instructions.Commands
{
    public class CancelInstructionCommand : IRequest<Unit>
    {
        public CancelInstructionCommand()
        {}
    }
}