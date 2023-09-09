using Microsoft.Extensions.DependencyInjection;
using PLaboratory.Core.Domain.Models.Users;
using PLaboratory.Core.Domain.Services.UserServices;
using PLaboratory.Test.Infrastructure;
using FluentAssertions;
using PLaboratory.Core.Domain.Contansts;
using PLaboratory.Core.Domain.Utils.Exceptions;

namespace PLaboratory.Test.Services.UserServices;

public class CreateUserServiceTest : BaseTest
{
    private readonly ICreateUserService _createUserService;

    public CreateUserServiceTest()
    {
        _createUserService = _serviceProvider.GetService<ICreateUserService>();
    }

    [Fact]
    public async Task ValidateSucess()
    {
        await _createUserService.ExecuteAsync(new CreateUserModel()
        { 
            Email = "teste@teste.com" + new Random().Next(0, 10000),
            Password = "123456",
            Name = "Lucas Everton Santos de Oliveira",
            UserGroupId = "F97E565D-08AF-4281-BC11-C0206EAE06FA",
            Username = "lcseverton" + new Random().Next(0, 10000)
        });

        var retorno = _createUserService.CreatedUser;

        retorno.Id.Should().NotBeNull();
    }

    [Fact]
    public async Task ValidateUserAlreadyExists()
    {
        Func<Task> action = async () =>
        {
            await _createUserService.ExecuteAsync(new CreateUserModel()
            {
                Email = "lcseverton@gmail.com" + new Random().Next(0, 10000),
                Password = "123456",
                Name = "Lucas Everton Santos de Oliveira",
                UserGroupId = "F97E565D-08AF-4281-BC11-C0206EAE06FA",
                Username = "lcseverton"
            });
        };

        await action.Should().ThrowAsync<BusinessException>().Where(ex => ex.Error == UserErrors.Business.ALREADY_USERNAME);
    }
}
