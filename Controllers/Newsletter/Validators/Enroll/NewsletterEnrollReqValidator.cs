using FluentValidation;
using JDPodrozeAPI.Controllers.Newsletter.Contracts.Requests;

namespace JDPodrozeAPI.Controllers.Newsletter.Validators
{
    public class NewsletterEnrollReqValidator : AbstractValidator<NewsletterEnrollReq>
    {
        public NewsletterEnrollReqValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}