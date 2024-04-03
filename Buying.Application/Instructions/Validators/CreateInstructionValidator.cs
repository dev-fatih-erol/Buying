using Buying.Application.Instructions.Requests;
using FluentValidation;

namespace Buying.Application.Instructions.Validators
{
    public class CreateInstructionValidator : AbstractValidator<CreateInstructionRequest>
    {
		public CreateInstructionValidator()
		{
            RuleFor(p => p.Amount)
                .GreaterThanOrEqualTo(500)
                .LessThanOrEqualTo(99999);

            RuleFor(p => p.ExecutionDay)
                .InclusiveBetween(1, 28);
        }
	}
}