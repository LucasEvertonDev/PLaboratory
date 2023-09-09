namespace PLaboratory.Core.Domain.Utils.Activator;

public static class App
{
    public static T Init<T>() where T : class
    {
        return System.Activator.CreateInstance<T>();
    }
}
