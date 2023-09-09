using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PLaboratory.Core.Application.Services.AuthServices;
using PLaboratory.Core.Application.Services.UserServices;
using PLaboratory.Core.Domain.DbContexts.Entities;
using PLaboratory.Core.Domain.DbContexts.Repositorys;
using PLaboratory.Core.Domain.DbContexts.UnitOfWork;
using PLaboratory.Core.Domain.Infra.AppSettings;
using PLaboratory.Core.Domain.Models.Users;
using PLaboratory.Core.Domain.Plugins.Cryptography;
using PLaboratory.Core.Domain.Plugins.IMappers;
using PLaboratory.Core.Domain.Plugins.JWT;
using PLaboratory.Core.Domain.Plugins.Validators;
using PLaboratory.Core.Domain.Services.AuthServices;
using PLaboratory.Core.Domain.Services.UserServices;
using PLaboratory.Infra.Data.Contexts;
using PLaboratory.Infra.Data.Contexts.Repositorys;
using PLaboratory.Infra.Data.Contexts.UnitOfWork;
using PLaboratory.Infra.IoC.Base;
using PLaboratory.Infra.IoC.Extensions;
using PLaboratory.Plugins.AutoMapper;
using PLaboratory.Plugins.AutoMapper.Profiles;
using PLaboratory.Plugins.FluentValidation.User;
using PLaboratory.Plugins.Hasher;
using PLaboratory.Plugins.TokenJWT;

namespace PLaboratory.Infra.IoC;

public class DependencyInjection: BaseDependencyInjection<AppSettings>
{
    public override void AddInfraSctructure(IServiceCollection services, AppSettings configuration)
    {
        // pra usar o middleware que não é attributee
        services.AddHttpContextAccessor();

        AddDbContexts(services, configuration);

        AddRepositorys(services, configuration);

        AddMappers(services, configuration);

        AddServices(services, configuration);

        AddValidators(services, configuration);
    }

    protected override void AddDbContexts(IServiceCollection services, AppSettings configuration)
    {
        services.AddDbContext<AuthDbContext>(options =>
        options.UseMySql(configuration.SqlConnections.DbConnection,
            ServerVersion.AutoDetect(configuration.SqlConnections.DbConnection)));

        services.AddScoped<IUnitOfWork, UnitOfWork<AuthDbContext>>();
    }

    protected override void AddMappers(IServiceCollection services, AppSettings configuration) 
    {
        services.AddScoped<IMapperPlugin, Mapper>();

        services.AddScoped(provider => new AutoMapper.MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapperProfile());
        }).CreateMapper());
    }

    protected override void AddRepositorys(IServiceCollection services, AppSettings configuration) 
    {
        services.AddRepository<User>();
        services.AddRepository<Role>();
        services.AddRepository<UserGroup>();
        services.AddRepository<MapUserGroupRoles>();
        services.AddRepository<ClientCredentials>();

        services.AddScoped<ISearchMapUserGroupRolesRepository, MapUserGroupRolesRepository>();
    }

    protected override void AddServices(IServiceCollection services, AppSettings configuration) 
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IPasswordHash, PasswordHash>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();

        services.AddScoped<ICreateUserService, CreateUserService>();
        services.AddScoped<IUpdateUserService, UpdateUserService>();
        services.AddScoped<IDeleteUserService, DeleteUserService>();
        services.AddScoped<ISearchUserService, SearchUserService>();
        services.AddScoped<IUpdatePasswordService, UpdatePasswordService>();
    }

    protected override void AddValidators(IServiceCollection services, AppSettings configuration)
    {
        services.AddTransient<IValidatorModel<CreateUserModel>, CreateUserValidator>();
        services.AddTransient<IValidatorModel<UpdateUserModel>, UpdateUserValidator>();
        services.AddTransient<IValidatorModel<UpdatePasswordUserModel>, UpdatePasswordUserValidator>();
    }
}
