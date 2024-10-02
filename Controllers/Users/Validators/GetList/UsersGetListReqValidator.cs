using FluentValidation;
using JDPodrozeAPI.Controllers.Users.Contracts.Requests;

namespace JDPodrozeAPI.Controllers.Users.Validators
{
    public class UsersGetListReqValidator : AbstractValidator<UsersGetListReq>
    {
        public UsersGetListReqValidator()
        {
            RuleFor(x => x.SearchText)
                .MaximumLength(100)
                .WithMessage("Search Text must have a maximum of 100 characeters");
        }
    }
}