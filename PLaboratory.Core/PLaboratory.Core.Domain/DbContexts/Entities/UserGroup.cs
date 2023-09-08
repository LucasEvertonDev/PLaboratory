﻿using MS.Libs.Core.Domain.DbContexts.Entities.Base;

namespace PLaboratory.Core.Domain.DbContexts.Entities
{
    public class UserGroup : BaseEntityBasic
    {
        public string Name { get; set; } 

        public string Description { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<MapUserGroupRoles> MapUserGroupRoles { get; set; }
    }
}
