using FluentValidation;

namespace JDPodrozeAPI.Controllers.Account.Contracts.Requests.Validators
{
    public class AccountLoginReqValidator : AbstractValidator<AccountLoginReq>
    {
        public AccountLoginReqValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}