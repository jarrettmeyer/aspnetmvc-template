using NHibernate;

namespace Project.Core.Lib.Infrastructure
{
    public interface INHibernateConfiguration
    {
        ISessionFactory BuildSessionFactory();
    }
}
