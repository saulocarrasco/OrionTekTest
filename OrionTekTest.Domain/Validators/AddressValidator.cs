using FluentValidation;
using OrionTekTest.Domain.Entities;

namespace OrionTekTest.Domain.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(p => p.Country)
             .NotEmpty()
             .WithMessage("Country is Required");
        }
    }
}
