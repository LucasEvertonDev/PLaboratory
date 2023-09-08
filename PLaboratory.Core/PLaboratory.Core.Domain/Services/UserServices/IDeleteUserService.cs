using PLaboratory.Core.Domain.Models.Users;

namespace PLaboratory.Core.Domain.Services.UserServices
{
    public interface IDeleteUserService
    {
        Task ExecuteAsync(DeleteUserDto param);
    }
}