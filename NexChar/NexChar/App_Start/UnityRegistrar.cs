using Microsoft.Practices.Unity;
using NexChar.App_Start;
using NexCharCore;

namespace NexChar
{
    public class UnityRegistrar
    {
        public static IUnityContainer BuildContainer()
        {
            IUnityContainer container = new UnityContainer();

            RegisterInterfaces(container);
            return container;
        }

        private static void RegisterInterfaces(IUnityContainer container)
        {
            container.RegisterType<IContextManager, ContextManager>(new HttpRequestLifetimeManager());
        }
    }
}