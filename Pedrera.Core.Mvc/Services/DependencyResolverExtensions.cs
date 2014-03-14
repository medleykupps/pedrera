using System.Web.Http.Dependencies;

namespace Pedrera.Core.Mvc.Services
{
    public static class DependencyResolverExtensions
    {
        public static T Get<T>(this IDependencyResolver resolver) where T : class
        {
            if (resolver == null)
                return default(T);

            return resolver.GetService(typeof (T)) as T;
        }
    }
}