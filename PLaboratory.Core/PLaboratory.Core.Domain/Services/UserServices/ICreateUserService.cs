using PLaboratory.Core.Domain.Models.Users;

namespace PLaboratory.Core.Domain.Services.UserServices
{
    public interface ICreateUserService
    {
        CreatedUserModel CreatedUser { get; set; }

        Task ExecuteAsync(CreateUserModel param);
    }
}