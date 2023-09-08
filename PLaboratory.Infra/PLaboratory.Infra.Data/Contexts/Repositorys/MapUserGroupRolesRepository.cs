using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PLaboratory.Core.Domain.DbContexts.Entities;
using PLaboratory.Core.Domain.DbContexts.Repositorys;
using PLaboratory.Infra.Data.Contexts.Repositorys.Base;

namespace PLaboratory.Infra.Data.Contexts.Repositorys;

public class MapUserGroupRolesRepository : Repository<MapUserGroupRoles>, ISearchMapUserGroupRolesRepository
{
    private readonly IMemoryCache _memoryCache;

    public MapUserGroupRolesRepository(IServiceProvider serviceProvider,
        IMemoryCache memoryCache) : base(serviceProvider)
    {
        _memoryCache = memoryCache;
    }

    public async Task<List<Role>> GetRolesByUserGroup(string userGroupId)
    {
        return await this.AsQueriable().Include(c => c.Role)
            .Where(p => p.UserGroupId.ToString() == userGroupId)
            .Select(a => a.Role)
            .ToListAsync();
    }
}
