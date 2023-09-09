using PLaboratory.Core.Domain.DbContexts.Entities.Base;

namespace PLaboratory.Core.Domain.Infra.Attributes;

public class ReflectAttribute<TEntity> : Attribute where TEntity : IEntity
{
    public Type EntityType => typeof(TEntity);
}
