using FluentValidation;
using MS.Libs.Core.Domain.DbContexts.Repositorys;
using MS.Libs.Core.Domain.Plugins.Validators;
using MS.Libs.Infra.Plugins.Validators;
using PLaboratory.Core.Domain.Contansts;
using PLaboratory.Core.Domain.DbContexts.Entities;
using PLaboratory.Core.Domain.Models.Users;
using PLaboratory.Plugins.FluentValidation.Extensions;

namespace PLaboratory.Plugins.FluentValidation.User;

public class UpdateUserValidator : BaseValidator<UpdateUserModel>, IValidatorModel<UpdateUserModel>
{
    public UpdateUserValidator(ISearchRepository<UserGroup> searchUserGroupRepository)
    {
        RuleFor(c => c.Username).NotNullOrEmpty().WithError(UserErrors.Validators.USERNAME_REQUIRED);
        RuleFor(c => c.Email).NotNullOrEmpty().WithError(UserErrors.Validators.EMAIL_REQUIRED);

        When(c => !string.IsNullOrWhiteSpace(c.Email), () =>
        {
            RuleFor(c => c.Email).EmailAddress().WithError(UserErrors.Validators.EMAIL_INVALID);
        });

        RuleFor(c => c.UserGroupId).NotNullOrEmpty().WithError(UserErrors.Validators.USER_GROUP_REQUIRED);

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
