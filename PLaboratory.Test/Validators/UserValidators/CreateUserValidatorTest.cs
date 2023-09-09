using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using PLaboratory.Core.Domain.Contansts;
using PLaboratory.Core.Domain.Models.Users;
using PLaboratory.Core.Domain.Plugins.Validators;
using PLaboratory.Core.Domain.Utils.Exceptions;
using PLaboratory.Test.Infrastructure;

namespace PLaboratory.Test.Validators.UserValidators;

public class CreateUserValidatorTest : BaseTest
{
    private readonly IValidatorModel<CreateUserModel> _createUserValidator;

    public CreateUserValidatorTest()
    {
        _createUserValidator = _serviceProvider.GetService<IValidatorModel<CreateUserModel>>();
    }

    [Fact]
    public async Task ValidateUsernameRequired()
    {
        Func<Task> action = async () =>
        {
            await _createUserValidator.ValidateModelAsync(new CreateUserModel()
            {
                Email = "lcseverton@gmail.com" + new Random().Next(0, 10000),
                Password = "123456",
                Name = "Lucas Everton Santos de Oliveira",
                UserGroupId = "F97E565D-08AF-4281-BC11-C0206EAE06FA",
            });
        };

        await action.Should().ThrowAsync<ValidatorException>().Where(ex => ex.ErrorsMessages != null 
            && ex.ErrorsMessages.Exists(a => a.ErrorCode == UserErrors.Validators.USERNAME_REQUIRED.Context));
    }

    [Fact]
    public async Task ValidateEmailInvalid()
    {
        Func<Task> action = async () =>
        {
            await _createUserValidator.ValidateModelAsync(new CreateUserModel()
            { 
                Username = "lcseverton",
                Email = "teste",
                Password = "123456",
                Name = "Lucas Everton Santos de Oliveira",
                UserGroupId = "F97E565D-08AF-4281-BC11-C0206EAE06FA",
            });
        };

        await action.Should().ThrowAsync<ValidatorException>().Where(ex => ex.ErrorsMessages != null
            && ex.ErrorsMessages.Exists(a => a.ErrorCode == UserErrors.Validators.EMAIL_INVALID.Context));
    }
}
