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

        public virtual void Commit()
        {
            using (var txn = _session.BeginTransaction())
            {
                txn.Commit();
            }            
        }

        public virtual void Delete<T>(T entity)
        {
            using (var txn = _session.BeginTransaction())
            {                
                _session.Delete(entity);
                txn.Commit();
            }            
        }

        public virtual void Insert<T>(T entity)
        {
            using (var txn = _session.BeginTransaction())
            {
                _session.Save(entity);
                txn.Commit();
            }
        }

        public virtual IQueryable<T> Find<T>(Expression<Func<T, bool>> expression)
        {
            return _session.Linq<T>().Where(expression);
        }

        public virtual IQueryable<T> FindAll<T>()
        {
            return _session.CreateCriteria(typeof(T)).List<T>().AsQueryable();
        }

        public virtual T FindById<T>(int id)
        {
            return _session.Get<T>(id);
        }

        public virtual T FindSingle<T>(Expression<Func<T, bool>> expression)
        {
            return _session.Linq<T>().FirstOrDefault(expression);
        }

        public virtual void Update<T>(T entity)
        {
            using (var txn = _session.BeginTransaction())
            {
                _session.Update(entity);
                txn.Commit();
            }
        }
    }
}
