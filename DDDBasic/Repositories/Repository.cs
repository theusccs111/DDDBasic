using DDDBasic.Application.Interfaces.Repository;
using DDDBasic.Domain.Entities.Base;
using DDDBasic.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DDDBasic.Persistence.Repositories
{
    public class Repository<T> : IRepository<T>, IDisposable where T : EntityBase
    {
        private readonly DDDBasicContext _context;

        public Repository(DDDBasicContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obter todos os dados
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        /// <summary>
        /// Obter dados filtrados por expressão lambda
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public T Search(params object[] key)
        {
            return _context.Set<T>().Find(key);
        }

        /// <summary>
        /// Obter primeiro registro conforme expressão lambda
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T GetFirst(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Func<T, bool> predicate)
        {
            _context.Set<T>().Where(predicate).ToList().ForEach(del => Delete(del));
        }

        public void Delete(T obj)
        {
            var entity = _context.Set<T>().Find(obj.Id);
            _context.Set<T>().Remove(entity);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
