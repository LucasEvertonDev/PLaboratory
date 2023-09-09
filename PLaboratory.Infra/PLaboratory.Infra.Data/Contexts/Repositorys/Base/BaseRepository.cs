using PLaboratory.Core.Domain.DbContexts.Entities.Base;

namespace PLaboratory.Infra.Data.Contexts.Repositorys.Base;

public class Repository<TEntity> : Repository<AuthDbContext, TEntity> where TEntity : BaseEntityBasic
{
    public Repository(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
