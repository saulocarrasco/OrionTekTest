using FluentValidation;
using OrionTekTest.Domain.Entities;

namespace OrionTekTest.Domain.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.FirstName)
             .NotEmpty()
             .WithMessage("Name is Required");

            RuleFor(p => p.LastName)
           .NotEmpty()
           .WithMessage("LastName is Required");

            RuleFor(p => p.Email).EmailAddress()
          .NotEmpty()
          .WithMessage("Email is Required");

            RuleFor(p => p.Phone)
          .NotEmpty()
          .WithMessage("Phone is Required");

            RuleFor(p => p.Addresses)
         .NotEmpty()
         .WithMessage("Addresses is Required");
        }
    }
}
