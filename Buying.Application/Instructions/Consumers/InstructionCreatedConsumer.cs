using Buying.Application.Instructions.Events;
using MassTransit;

namespace Buying.Application.Instructions.Consumers
{
    public class InstructionCreatedConsumer : IConsumer<InstructionCreatedEvent>
    {
		public InstructionCreatedConsumer()
		{
		}

        public async Task Consume(ConsumeContext<InstructionCreatedEvent> context)
        {
            await Task.Delay(1000);
        }
    }
}