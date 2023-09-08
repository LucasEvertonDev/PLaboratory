﻿using MS.Libs.Core.Domain.DbContexts.Entities.Base;
using MS.Libs.Infra.Data.Context.Repositorys;

namespace PLaboratory.Infra.Data.Contexts.Repositorys.Base;

public class Repository<TEntity> : BaseRepository<AuthDbContext, TEntity> where TEntity : BaseEntityBasic
{
    public Repository(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
