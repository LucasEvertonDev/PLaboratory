using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PLaboratory.Core.Domain.DbContexts.Entities.Base;
using PLaboratory.Core.Domain.DbContexts.Enuns;

namespace PLaboratory.Infra.Data.Contexts.Configurations.Base;

public class BaseEntityBasicConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : BaseEntityBasic
{
    public virtual void Configure(EntityTypeBuilder<TBase> builder)
    {
        builder.HasQueryFilter(x => x.Situation != (int)Situation.Deleted);

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(u => u.Situation).IsRequired().HasDefaultValue(Situation.Active);
    }
}

