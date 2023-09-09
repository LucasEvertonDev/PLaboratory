namespace PLaboratory.Core.Domain.Utils.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static TInstance GetService<TInstance>(this IServiceProvider serviceProvider)
        {
            return (TInstance)serviceProvider.GetService(typeof(TInstance));
        }
    }
}
