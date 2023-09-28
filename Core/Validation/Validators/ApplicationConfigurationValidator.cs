using FluentValidation;
using JDPodrozeAPI.Core.Models.Configuration;

namespace JDPodrozeAPI.Core.Validation.Validators
{
    public class ApplicationConfigurationValidator : AbstractValidator<ApplicationConfiguration>
    {
        public ApplicationConfigurationValidator()
        {
            RuleFor(x => x.ParameterStore.Credentials).NotNull().NotEmpty();
            RuleFor(x => x.ParameterStore.Credentials.AccessKey).NotNull().NotEmpty();
            RuleFor(x => x.ParameterStore.Credentials.SecretKey).NotNull().NotEmpty();
            RuleFor(x => x.Authentication.SigningKey).NotNull().NotEmpty();
            RuleFor(x => x.Authentication.Issuer).NotNull().NotEmpty();
            RuleFor(x => x.Authentication.Audience).NotNull().NotEmpty();
            RuleFor(x => x.Database.ConnectionString).NotNull().NotEmpty();
            RuleFor(x => x.Cryptography.Salt).NotNull().NotEmpty();
            RuleFor(x => x.SMTP.Email).NotNull().NotEmpty();
            RuleFor(x => x.SMTP.Password).NotNull().NotEmpty();
        }
    }
}