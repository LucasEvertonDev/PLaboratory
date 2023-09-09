using PLaboratory.Core.Domain.DbContexts.Entities.Base;
using PLaboratory.Core.Domain.Infra.Attributes;

namespace PLaboratory.Core.Domain.DbContexts.Entities;

[Cache(Key: "MapUserGroupRoles", AbsoluteExpirationInMinutes: 2, SlidingExpirationInMinutes: 2)]
public class MapUserGroupRoles : BaseEntityBasic
{
    public Guid UserGroupId { get; set; }
    public Guid RoleId { get; set; }
    public UserGroup UserGroup { get; set; }
    public Role Role { get; set; }
}
