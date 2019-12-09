using DDDBasic.Domain.Entities.Base;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DDDBasic.Application.Interfaces.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        T Search(params object[] key);
        T GetFirst(Expression<Func<T, bool>> predicate);
        void Create(T entity);
        void Update(T entity);
        void Delete(Func<T, bool> predicate);
        void Delete(T obj);
        void Commit();
        void Dispose();
    }
}
