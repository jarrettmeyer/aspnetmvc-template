using System;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;

namespace Project.Core.Lib.Data
{
    public class SqlRepository : IRepository
    {
        private readonly ISession _session;

        public SqlRepository(ISession session)
        {
            Ensure.ArgumentNotNull(session, "session");
            _session = session;
        }

        public void Commit()
        {
            using (var txn = _session.BeginTransaction())
            {
                txn.Commit();
            }            
        }

        public void Delete<T>(T entity)
        {
            _session.Delete(entity);
        }

        public void Insert<T>(T entity)
        {
            using (var txn = _session.BeginTransaction())
            {
                _session.Save(entity);
                txn.Commit();
            }
        }

        public IQueryable<T> Find<T>(Expression<Func<T, bool>> expression)
        {
            return _session.Linq<T>().Where(expression);
        }

        public T FindById<T>(int id)
        {
            return _session.Get<T>(id);
        }

        public T FindSingle<T>(Expression<Func<T, bool>> expression)
        {
            return _session.Linq<T>().FirstOrDefault(expression);
        }

        public void Update<T>(T entity)
        {
            using (var txn = _session.BeginTransaction())
            {
                _session.Update(entity);
                txn.Commit();
            }
        }
    }
}
