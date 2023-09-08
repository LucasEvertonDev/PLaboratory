using PLaboratory.Core.Domain.Models.Users;

namespace PLaboratory.Core.Domain.Services.UserServices
{
    public interface IUpdateUserService
    {
        UpdatedUserModel UpdatedUser { get; set; }

        Task ExecuteAsync(UpdateUserDto param);
    }
}