using DDDBasic.Application.Interfaces.Repository;
using DDDBasic.Domain.Entities.Base;
using DDDBasic.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasic.Persistence.Repositories
{
    //public class Repository<TEntityBase> : IRepository<TEntityBase> where TEntityBase : EntityBase
    //{
    //    private readonly DDDBasic_context __context;
    //    public Repository(DDDBasic_context _context)
    //    {
    //        __context = _context;
    //    }

    //    public void Create(TEntityBase obj)
    //    {
    //        __context.Set<TEntityBase>().Add(obj);
    //    }

    //    public void Delete(TEntityBase obj)
    //    {
    //        var entity = __context.Set<TEntityBase>().Find(obj.Id);
    //        __context.Set<TEntityBase>().Remove(entity);
    //    }

    //    public async Task<IEnumerable<TEntityBase>> Get()
    //    {
    //        return await __context.Set<TEntityBase>().ToListAsync();
    //    }

    //    public async Task<IEnumerable<TEntityBase>> Get(Expression<Func<TEntityBase, bool>> predicate)
    //    {
    //        return await __context.Set<TEntityBase>().Where(predicate).ToListAsync();
    //    }

    //    public async Task<TEntityBase> GetById(int Id)
    //    {
    //        return await __context.Set<TEntityBase>().FindAsync(Id);
    //    }

    //    public void Update(TEntityBase obj)
    //    {
    //        __context.Set<TEntityBase>().Update(obj);
    //    }
    //}

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
