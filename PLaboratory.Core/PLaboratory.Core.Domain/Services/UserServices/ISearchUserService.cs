using PLaboratory.Core.Domain.Models.Base;
using PLaboratory.Core.Domain.Models.Users;

namespace PLaboratory.Core.Domain.Services.UserServices
{
    public interface ISearchUserService
    {
        PagedResult<SearchedUserModel> SearchedUsers { get; }

        Task ExecuteAsync(SeacrhUserDto param);
    }
}