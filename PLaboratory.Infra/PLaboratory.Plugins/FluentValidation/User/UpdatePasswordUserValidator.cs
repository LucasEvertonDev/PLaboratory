using FluentValidation;
using MS.Libs.Core.Domain.Plugins.Validators;
using MS.Libs.Infra.Plugins.Validators;
using PLaboratory.Core.Domain.Contansts;
using PLaboratory.Core.Domain.Models.Users;
using PLaboratory.Plugins.FluentValidation.Extensions;

namespace PLaboratory.Plugins.FluentValidation.User;

public class UpdatePasswordUserValidator : BaseValidator<UpdatePasswordUserModel>, IValidatorModel<UpdatePasswordUserModel>
{
    public UpdatePasswordUserValidator()
    {
        RuleFor(c => c.Password).NotNullOrEmpty().WithError(UserErrors.Validators.PASSWORD_REQUIRED);

        When(c => !string.IsNullOrWhiteSpace(c.Password), () =>
        {
            RuleFor(c => c.Password.Length).GreaterThanOrEqualTo(6).WithError(UserErrors.Validators.PASSWORD_LENGTH);
        });
    }
}
