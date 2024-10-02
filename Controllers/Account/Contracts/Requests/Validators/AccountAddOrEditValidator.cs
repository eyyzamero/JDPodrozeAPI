using FluentValidation;

namespace JDPodrozeAPI.Controllers.Account.Contracts.Requests.Validators
{
    public class AccountAddOrEditValidator : AbstractValidator<AccountAddOrEditReq>
    {
        public AccountAddOrEditValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Login is required")
                .Length(8, 50).WithMessage("Password must be between 8 and 50 characters");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .Length(8, 50).WithMessage("Password must be between 8 and 50 characters")
                .When(x => x.Id == null)
                .When(x => string.IsNullOrEmpty(x.Password));

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(50).WithMessage("First name must have a maximum of 50 characeters");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50).WithMessage("Last name must have a maximum of 50 characeters");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(255).WithMessage("Email must have a maximum of 50 characeters");
        }
    }
}