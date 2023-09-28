using FluentValidation;
using JDPodrozeAPI.Controllers.Excursions.Contracts.Requests;

namespace JDPodrozeAPI.Controllers.Excursions.Validators
{
    public class ExcursionsEnrollReqValidator : AbstractValidator<ExcursionsEnrollReq>
    {
        public ExcursionsEnrollReqValidator()
        {
            RuleFor(x => x.ExcursionId).NotNull().NotEmpty();
            RuleFor(x => x.Booker).NotNull().NotEmpty().ChildRules(booker =>
            {
                booker.RuleFor(i => i.Name).NotNull().NotEmpty().MaximumLength(50);
                booker.RuleFor(i => i.Surname).NotNull().NotEmpty().MaximumLength(50);
                booker.RuleFor(i => i.Email).NotNull().NotEmpty().MaximumLength(150);
                booker.RuleFor(i => i.TelephoneNumber).NotNull().NotEmpty().MaximumLength(12);
                booker.RuleFor(i => i.BirthDate).NotNull().NotEmpty();
            });
            RuleForEach(x => x.Participants).ChildRules(participant =>
            {
                participant.RuleFor(i => i.Name).NotNull().NotEmpty().MaximumLength(50);
                participant.RuleFor(i => i.Surname).NotNull().NotEmpty().MaximumLength(50);
                participant.RuleFor(i => i.BirthDate).NotNull().NotEmpty();
            }).When(x => x.Participants != null);
            RuleFor(x => x.PaymentMethod).Null().NotEmpty().Must(x => x == 'T' || x == 'P');
        }
    }
}
