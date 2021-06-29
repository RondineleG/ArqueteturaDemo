using FluentValidation;
using Proton.Register.Domain.Core.Models;

namespace Proton.Register.Domain.Validators
{
    public class CityValidator : AbstractValidator<City>{
        public CityValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.NameCity)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")  
                
                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.")

                .MaximumLength(80)
                .WithMessage("O nome deve ter no máximo 80 caracteres.");
        }
    }
}