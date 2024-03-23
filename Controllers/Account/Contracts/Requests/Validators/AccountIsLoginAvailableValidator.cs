using FluentValidation;

namespace JDPodrozeAPI.Controllers.Account.Contracts.Requests.Validators
{
    public class AccountIsLoginAvailableValidator : AbstractValidator<AccountIsLoginAvailableReq>
    {
        public AccountIsLoginAvailableValidator()
        {
            RuleFor(x => x.Login).NotNull().NotEmpty();
        }
    }
}