using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PLaboratory.Core.Domain.DbContexts.Entities.Base;

namespace PLaboratory.Infra.Data.Contexts.Configurations.Base;

public class BaseEntityConfiguration<TEntity> : BaseEntityBasicConfiguration<TEntity> where TEntity : BaseEntity
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);
        builder.Property(u => u.CreateDate);
    }
}
