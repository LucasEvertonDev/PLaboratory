using PLaboratory.Core.Domain.Models.Users;

namespace PLaboratory.Core.Domain.Services.UserServices;

public interface IUpdatePasswordService
{
    Task ExecuteAsync(UpdatePasswordUserDto param);
}