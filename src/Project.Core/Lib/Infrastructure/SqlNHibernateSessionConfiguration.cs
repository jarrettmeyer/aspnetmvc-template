using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Project.Core.Models;

namespace Project.Core.Lib.Infrastructure
{
    public class SqlNHibernateSessionConfiguration
    {
        private const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Sample;Integrated Security=True;";

        public ISessionFactory BuildSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionString).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Contact>())
                .BuildSessionFactory();
        }
    }
}
