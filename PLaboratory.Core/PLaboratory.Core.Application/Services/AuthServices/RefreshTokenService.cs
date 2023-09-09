using PLaboratory.Core.Application.Services.Base;
using PLaboratory.Core.Domain.Contansts;
using PLaboratory.Core.Domain.DbContexts.Entities;
using PLaboratory.Core.Domain.DbContexts.Repositorys;
using PLaboratory.Core.Domain.DbContexts.Repositorys.Base;
using PLaboratory.Core.Domain.Infra.Claims;
using PLaboratory.Core.Domain.Models.Auth;
using PLaboratory.Core.Domain.Models.Error;
using PLaboratory.Core.Domain.Plugins.JWT;
using PLaboratory.Core.Domain.Services.AuthServices;
using PLaboratory.Core.Domain.Utils.Extensions;
using System.Runtime.Serialization;

namespace PLaboratory.Core.Application.Services.AuthServices;

public class RefreshTokenService : BaseService<RefreshTokenDto>, IRefreshTokenService
{
    private readonly ISearchRepository<User> _searchUserRepository;
    private readonly ISearchMapUserGroupRolesRepository _mapuserGroupSearchRepository;
    private readonly ITokenService _tokenService;
    private readonly IUpdateRepository<User> _updateUserRepository;
    private readonly ISearchRepository<ClientCredentials> _searchClientCredentials;

    public TokenModel TokenRetorno { get; private set; }

    public RefreshTokenService(IServiceProvider serviceProvider,
        ISearchRepository<User> searchUserRepository,
        IUpdateRepository<User> updateUserRepository,
        ISearchRepository<ClientCredentials> searchClientCredentials,
        ISearchMapUserGroupRolesRepository mapuserGroupSearchRepository,
        ITokenService tokenService
    )
        : base(serviceProvider)
    {
        _searchUserRepository = searchUserRepository;
        _mapuserGroupSearchRepository = mapuserGroupSearchRepository;
        _tokenService = tokenService;
        _updateUserRepository = updateUserRepository;
        _searchClientCredentials = searchClientCredentials;
    }

    public override async Task ExecuteAsync(RefreshTokenDto refreshTokenDto)
    {
        await OnTransactionAsync(async () =>
        {
            await ValidateAsync(refreshTokenDto);

            var user = await _searchUserRepository.FirstOrDefaultAsync(user => user.Id.ToString() == _identity.GetUserClaim(JWTUserClaims.UserId));

            user.LastAuthentication = DateTime.Now;

            var roles = await _mapuserGroupSearchRepository.GetRolesByUserGroup(user.UserGroupId.ToString());

            var (tokem, data) = await _tokenService.GenerateToken(user, refreshTokenDto.ClientId, roles);

            await _updateUserRepository.UpdateAsync(user);

            this.TokenRetorno = new TokenModel
            {
                TokenJWT = tokem,
                DataExpiracao = data.ToLocalTime()
            };
        });
    }

    protected override async Task ValidateAsync(RefreshTokenDto refreshTokenDto)
    {
        if (!(await _searchClientCredentials.GetListFromCacheAsync(a => a.ClientId == new Guid(refreshTokenDto.ClientId) && a.ClientSecret == refreshTokenDto.ClientSecret)).Any())
        {
            BusinessException(AuthErrors.Business.CLIENT_CREDENTIALS_INVALID);
        }

        var user = await _searchUserRepository.FirstOrDefaultAsync(user => user.Id.ToString() == _identity.GetUserClaim(JWTUserClaims.UserId));

        if (user == null)
        {
            throw new BusinessException(AuthErrors.Business.INVALID_REFRESH_TOKEN);
        }
    }
}

[Serializable]
internal class BusinessException : Exception
{
    private ErrorModel iNVALID_REFRESH_TOKEN;

    public BusinessException()
    {
    }

    public BusinessException(ErrorModel iNVALID_REFRESH_TOKEN)
    {
        this.iNVALID_REFRESH_TOKEN = iNVALID_REFRESH_TOKEN;
    }

    public BusinessException(string message) : base(message)
    {
    }

    public BusinessException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}