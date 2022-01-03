using FluentValidation;
using Proton.Register.Domain.Core.Models;

namespace Proton.Register.Domain.Validations
{
    public class TerminalValidation : AbstractValidator<Terminal>
    {
        public TerminalValidation()
        {
            RuleFor(c => c.NameTerminal)
                .NotEmpty().WithMessage("The field {PropertyName} is required!")
                .Length(2, 100).WithMessage("The field {PropertyName}need has {MinLength} and {MaxLength} caracters");
        }
    }
}