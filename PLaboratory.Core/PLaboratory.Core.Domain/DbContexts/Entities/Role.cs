using PLaboratory.Core.Domain.DbContexts.Entities.Base;

namespace PLaboratory.Core.Domain.DbContexts.Entities;

public class Role : BaseEntityBasic
{
    public string Name { get; set; }

    public ICollection<MapUserGroupRoles> MapUserGroupRoles { get; set; }
}
