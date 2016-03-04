using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;


namespace SierraPacific.Bootstrapper
{
    public enum BootStrapperType
    {
        WebApi,
        WebApiTest,
        ServiceTest,
        RepositoryTest
    }
    public class ApiDependencyResolver
    {

        public static IDependencyResolver Get()
        {
            return UnityConfig.Resolver;
        }

        public static void Shutdown()
        {
            var container = UnityConfig.GetConfiguredContainer();
            container.Dispose();
        }

        public static T Resolve<T>()
        {
            var container = UnityConfig.GetConfiguredContainer();
            return container.Resolve<T>();
        }

    }
}
