using MS.Libs.Core.Domain.DbContexts.Repositorys;
using PLaboratory.Core.Domain.DbContexts.Entities;

namespace PLaboratory.Core.Domain.DbContexts.Repositorys;

public interface ISearchMapUserGroupRolesRepository : ISearchRepository<MapUserGroupRoles>
{
    Task<List<Role>> GetRolesByUserGroup(string userGroupId);
}
