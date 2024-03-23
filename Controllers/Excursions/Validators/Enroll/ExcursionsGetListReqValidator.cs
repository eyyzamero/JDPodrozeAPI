using FluentValidation;
using JDPodrozeAPI.Controllers.Excursions.Contracts.Requests;

namespace JDPodrozeAPI.Controllers.Excursions.Validators.Enroll
{
    public class ExcursionsGetListReqValidator : AbstractValidator<ExcursionsGetListReq>
    {
        public ExcursionsGetListReqValidator()
        {
            RuleFor(x => x.Sort).IsInEnum();
        }
    }
}