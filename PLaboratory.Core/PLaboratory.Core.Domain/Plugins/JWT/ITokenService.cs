using PLaboratory.Core.Domain.DbContexts.Entities;

namespace PLaboratory.Core.Domain.Plugins.JWT
{
    public interface ITokenService
    {
        Task<(string, DateTime)> GenerateToken(User user, string clientId, List<Role> roles);
    }
}