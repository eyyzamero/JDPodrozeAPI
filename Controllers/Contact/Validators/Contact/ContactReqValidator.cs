using FluentValidation;
using JDPodrozeAPI.Controllers.Contact.Contracts.Requests;

namespace JDPodrozeAPI.Controllers.Contact.Validators
{
    public class ContactReqValidator : AbstractValidator<ContactReq>
    {
        public ContactReqValidator()
        {
            RuleFor(x => x.NameAndSurname).NotNull().NotNull().MaximumLength(100);
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress().MaximumLength(150);
            RuleFor(x => x.Content).NotNull().NotEmpty().MaximumLength(1024);
        }
    }
}