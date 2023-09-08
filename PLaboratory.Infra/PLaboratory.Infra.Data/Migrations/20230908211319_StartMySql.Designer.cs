﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PLaboratory.Infra.Data.Contexts;

#nullable disable

namespace PLaboratory.Infra.Data.Migrations
{
    [DbContext(typeof(AuthDbContext))]
    [Migration("20230908211319_StartMySql")]
    partial class StartMySql
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PLaboratory.Core.Domain.DbContexts.Entities.ClientCredentials", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("char(50)");

                    b.Property<string>("ClientDescription")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<Guid>("ClientId")
                        .HasMaxLength(50)
                        .HasColumnType("char(50)");

                    b.Property<string>("ClientSecret")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("Situation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("ClientsCredentials", (string)null);
                });

            modelBuilder.Entity("PLaboratory.Core.Domain.DbContexts.Entities.MapUserGroupRoles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("char(50)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(50)");

                    b.Property<int>("Situation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<Guid>("UserGroupId")
                        .HasColumnType("char(50)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserGroupId");

                    b.ToTable("MapUserGroupRoles", (string)null);
                });

            modelBuilder.Entity("PLaboratory.Core.Domain.DbContexts.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("char(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("Situation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("PLaboratory.Core.Domain.DbContexts.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("char(50)");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("LastAuthentication")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<int>("Situation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserGroupId")
                        .HasColumnType("char(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("UserGroupId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("PLaboratory.Core.Domain.DbContexts.Entities.UserGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("char(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Situation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.ToTable("UserGroups", (string)null);
                });

            modelBuilder.Entity("PLaboratory.Core.Domain.DbContexts.Entities.MapUserGroupRoles", b =>
                {
                    b.HasOne("PLaboratory.Core.Domain.DbContexts.Entities.Role", "Role")
                        .WithMany("MapUserGroupRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PLaboratory.Core.Domain.DbContexts.Entities.UserGroup", "UserGroup")
                        .WithMany("MapUserGroupRoles")
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("PLaboratory.Core.Domain.DbContexts.Entities.User", b =>
                {
                    b.HasOne("PLaboratory.Core.Domain.DbContexts.Entities.UserGroup", "UserGroup")
                        .WithMany("Users")
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("PLaboratory.Core.Domain.DbContexts.Entities.Role", b =>
                {
                    b.Navigation("MapUserGroupRoles");
                });

            modelBuilder.Entity("PLaboratory.Core.Domain.DbContexts.Entities.UserGroup", b =>
                {
                    b.Navigation("MapUserGroupRoles");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}