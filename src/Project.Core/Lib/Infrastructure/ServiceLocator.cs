using Ninject;
using Ninject.Modules;

namespace Project.Core.Lib.Infrastructure
{
    public static class ServiceLocator
    {
        private static IKernel _kernel;

        public static T Resolve<T>()
        {
            return _kernel.Get<T>();
        }

        public static IKernel BuildKernel()
        {
            var modules = new INinjectModule[]
            {
                new LoggingModule(),
                new NHibernateModule(),
                new WebContextModule()
            };
            _kernel = new StandardKernel(modules);            
            return _kernel;
        }
    }
}
