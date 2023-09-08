using MS.Libs.Core.Domain.DbContexts.Entities.Base;
using MS.Libs.Core.Domain.Infra.Attributes;

namespace PLaboratory.Core.Domain.DbContexts.Entities;

public class Role : BaseEntityBasic
{
    public string Name { get; set; }

    public ICollection<MapUserGroupRoles> MapUserGroupRoles { get; set; }
}
