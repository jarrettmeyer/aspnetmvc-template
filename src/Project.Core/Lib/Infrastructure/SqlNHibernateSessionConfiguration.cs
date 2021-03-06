﻿using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Project.Core.Models.Entities;

namespace Project.Core.Lib.Infrastructure
{
    public class SqlNHibernateSessionConfiguration
    {
        private const string ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=AspNetMvcTemplate;Persist Security Info=True;Integrated Security=true";

        public ISessionFactory BuildSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionString).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Contact>())
                .BuildSessionFactory();
        }
    }
}
