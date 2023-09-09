﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PLaboratory.Core.Domain.DbContexts.Entities;
using PLaboratory.Core.Domain.DbContexts.Enuns;
using PLaboratory.Infra.Data.Contexts.Configurations.Base;

namespace PLaboratory.Infra.Data.Contexts.Configurations;

public class RoleConfiguration : BaseEntityBasicConfiguration<Role>
{
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
        base.Configure(builder);

        builder.ToTable("Roles");

        builder.Property(u => u.Name).HasMaxLength(30).IsRequired();

        DefaultData(builder);
    }

    public void DefaultData(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(new Role
        {
            Id = new Guid("bbdbc055-b8b9-42af-b667-9a18c854ee8e"),
            Name = "CHANGE_STUDENTS",
            Situation = (int)Situation.Active
        });
    }
}
