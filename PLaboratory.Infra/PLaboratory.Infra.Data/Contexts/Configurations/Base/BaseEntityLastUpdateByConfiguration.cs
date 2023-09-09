using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PLaboratory.Core.Domain.DbContexts.Entities.Base;

namespace PLaboratory.Infra.Data.Contexts.Configurations.Base;

public class BaseEntitLastUpdateByConfiguration<TEntity> : BaseEntityConfiguration<TEntity> where TEntity : BaseEntityLastUpdateBy
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);
        builder.Property(u => u.LastUpdateBy).HasMaxLength(50);
    }
}
