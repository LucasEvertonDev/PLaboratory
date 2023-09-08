using PLaboratory.Core.Domain.Models.Auth;

namespace PLaboratory.Core.Domain.Services.AuthServices
{
    public interface IRefreshTokenService
    {
        TokenModel TokenRetorno { get; }

        Task ExecuteAsync(RefreshTokenDto refreshTokenDto);
    }
}