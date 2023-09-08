﻿using Microsoft.Extensions.DependencyInjection;
using MS.Libs.Core.Domain.DbContexts.Entities.Base;
using MS.Libs.Core.Domain.DbContexts.Repositorys;
using PLaboratory.Core.Domain.DbContexts.Entities;
using PLaboratory.Infra.Data.Contexts.Repositorys.Base;

namespace PLaboratory.Infra.IoC.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepository<TEntity>(this IServiceCollection services) where TEntity : BaseEntityBasic
        {
            services.AddScoped<ICreateRepository<TEntity>, Repository<TEntity>>();
            services.AddScoped<ISearchRepository<TEntity>, Repository<TEntity>>();
            services.AddScoped<IDeleteRepository<TEntity>, Repository<TEntity>>();
            services.AddScoped<IUpdateRepository<TEntity>, Repository<TEntity>>();
        }

        public static void AddRepository<TEntity, TRepository>(this IServiceCollection services) where TEntity : BaseEntityBasic where TRepository : Repository<TEntity>
        {
            services.AddScoped<ICreateRepository<TEntity>, TRepository>();
            services.AddScoped<ISearchRepository<TEntity>, TRepository>();
            services.AddScoped<IDeleteRepository<TEntity>, TRepository>();
            services.AddScoped<IUpdateRepository<TEntity>, TRepository>();
        }
    }
}
