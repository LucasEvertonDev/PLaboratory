using FluentValidation;
using PLaboratory.Core.Domain.Contansts;
using PLaboratory.Core.Domain.DbContexts.Entities;
using PLaboratory.Core.Domain.DbContexts.Repositorys.Base;
using PLaboratory.Core.Domain.Models.Users;
using PLaboratory.Core.Domain.Plugins.Validators;
using PLaboratory.Plugins.FluentValidation.Extensions;

namespace PLaboratory.Plugins.FluentValidation.User;

public class CreateUserValidator : BaseValidator<CreateUserModel>, IValidatorModel<CreateUserModel>
{
    public CreateUserValidator(ISearchRepository<UserGroup> searchUserGroupRepository)
    {
        RuleFor(c => c.Username).NotNullOrEmpty().WithError(UserErrors.Validators.USERNAME_REQUIRED);
        RuleFor(c => c.Email).NotNullOrEmpty().WithError(UserErrors.Validators.EMAIL_REQUIRED);

        When(c => !string.IsNullOrWhiteSpace(c.Email), () =>
        {
            RuleFor(c => c.Email).EmailAddress().WithError(UserErrors.Validators.EMAIL_INVALID);
        });

        RuleFor(c => c.Password).NotNullOrEmpty().WithError(UserErrors.Validators.PASSWORD_REQUIRED);

        RuleFor(c => c.UserGroupId).NotNullOrEmpty().WithError(UserErrors.Validators.USER_GROUP_REQUIRED);

        When(c => !string.IsNullOrWhiteSpace(c.Password), () =>
        {
            RuleFor(c => c.Password.Length).GreaterThanOrEqualTo(6).WithError(UserErrors.Validators.PASSWORD_LENGTH);
        });

        RuleFor(x => x.UserGroupId).MustAsync(async (userGroup, cancelation) =>
        {
            if (!string.IsNullOrEmpty(userGroup))
            {
                return !((await searchUserGroupRepository.FirstOrDefaultAsync(u => u.Id.ToString() == userGroup)) == null);
            }
            return true;
        }).WithError(UserErrors.Validators.USER_GROUP_NOT_FOUND);
    }
}
