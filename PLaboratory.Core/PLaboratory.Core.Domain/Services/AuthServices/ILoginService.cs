using PLaboratory.Core.Domain.Models.Auth;

namespace PLaboratory.Core.Domain.Services.AuthServices
{
    public interface ILoginService
    {
        TokenModel TokenRetorno { get; set; }

        Task ExecuteAsync(LoginDto param);
    }
}