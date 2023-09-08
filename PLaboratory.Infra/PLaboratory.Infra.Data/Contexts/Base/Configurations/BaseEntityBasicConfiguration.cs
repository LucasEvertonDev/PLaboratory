﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MS.Libs.Core.Domain.DbContexts.Enuns;
using MS.Libs.Core.Domain.DbContexts.Entities.Base;

namespace MS.Libs.Infra.Data.Context.Configurations;

public class BaseEntityBasicConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : BaseEntityBasic
{
    public virtual void Configure(EntityTypeBuilder<TBase> builder)
    {
        builder.HasQueryFilter(x => x.Situation != (int)Situation.Deleted);

        builder.HasKey(u => u.Id);
       
        builder.Property(u => u.Id).HasMaxLength(50).ValueGeneratedOnAdd().IsRequired();
        builder.Property(u => u.Situation).IsRequired().HasDefaultValue(Situation.Active);
    }
}

