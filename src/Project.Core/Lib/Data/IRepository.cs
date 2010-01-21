using System;
using System.Linq;
using System.Linq.Expressions;

namespace Project.Core.Lib.Data
{
    public interface IRepository
    {
        void Commit();
        void Delete<T>(T entity);
        void Insert<T>(T entity);
        IQueryable<T> Find<T>(Expression<Func<T, bool>> expression);
        IQueryable<T> FindAll<T>();
        T FindById<T>(int id);
        T FindSingle<T>(Expression<Func<T, bool>> expression);
        void Update<T>(T entity);
    }
}
