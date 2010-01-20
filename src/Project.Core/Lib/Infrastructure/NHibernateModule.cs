using NHibernate;
using Ninject.Modules;
using Project.Core.Lib.Data;

namespace Project.Core.Lib.Infrastructure
{
    public class NHibernateModule : NinjectModule
    {
        private readonly ISessionFactory _sessionFactory;

        public NHibernateModule()
        {
            _sessionFactory = new SqlNHibernateSessionConfiguration().BuildSessionFactory();
        }

        public override void Load()
        {
            Bind<IRepository>().To<SqlRepository>();
            Bind<ISession>().ToMethod(c => OpenSession()).InRequestScope();
        }

        private ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
