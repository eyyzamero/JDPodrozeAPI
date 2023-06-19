using FluentValidation;

namespace JDPodrozeAPI.Controllers.Account.Contracts.Requests.Validators
{
    public class AccountLoginReqValidator : AbstractValidator<AccountLoginReq>
    {
        public AccountLoginReqValidator()
        {
            RuleFor(x => x.Login).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}