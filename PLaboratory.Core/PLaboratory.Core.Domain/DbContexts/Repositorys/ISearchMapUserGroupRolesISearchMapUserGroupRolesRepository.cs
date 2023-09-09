using PLaboratory.Core.Domain.DbContexts.Entities;
using PLaboratory.Core.Domain.DbContexts.Repositorys.Base;

namespace PLaboratory.Core.Domain.DbContexts.Repositorys;

public interface ISearchMapUserGroupRolesRepository : ISearchRepository<MapUserGroupRoles>
{
    Task<List<Role>> GetRolesByUserGroup(string userGroupId);
}
