using Microsoft.Extensions.DependencyInjection;
using PLaboratory.Core.Domain.Infra.AppSettings;

namespace PLaboratory.Infra.IoC.Base
{
    public abstract class BaseDependencyInjection<TConfig> where TConfig : AppSettings
    {
        public abstract void AddInfraSctructure(IServiceCollection services, TConfig configuration);

        protected abstract void AddDbContexts(IServiceCollection services, TConfig configuration);

        protected abstract void AddServices(IServiceCollection services, TConfig configuration);

        protected abstract void AddValidators(IServiceCollection services, TConfig configuration);

        protected abstract void AddRepositorys(IServiceCollection services, TConfig configuration);

        protected abstract void AddMappers(IServiceCollection services, TConfig configuration);
    }
}
