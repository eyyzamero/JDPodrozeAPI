using FluentValidation;

namespace JDPodrozeAPI.Controllers.Account.Contracts.Requests.Validators
{
    public class AccountRegisterReqValidator : AbstractValidator<AccountRegisterReq>
    {
        public AccountRegisterReqValidator()
        {
            RuleFor(x => x.Login).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(255);
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress().MaximumLength(255);
        }
    }
}