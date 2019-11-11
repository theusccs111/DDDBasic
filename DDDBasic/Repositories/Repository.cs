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
    public class Repository<TEntityBase> : IRepository<TEntityBase> where TEntityBase : EntityBase
    {
        private readonly DDDBasicContext _context;
        public Repository(DDDBasicContext context)
        {
            _context = context;
        }

        public void Create(TEntityBase obj)
        {
            _context.Set<TEntityBase>().Add(obj);
        }

        public void Delete(TEntityBase obj)
        {
            var entity = _context.Set<TEntityBase>().Find(obj.Id);
            _context.Set<TEntityBase>().Remove(entity);
        }

        public async Task<IEnumerable<TEntityBase>> Get()
        {
            return await _context.Set<TEntityBase>().ToListAsync();
        }

        public async Task<IEnumerable<TEntityBase>> Get(Expression<Func<TEntityBase, bool>> predicate)
        {
            return await _context.Set<TEntityBase>().Where(predicate).ToListAsync();
        }

        public async Task<TEntityBase> GetById(int Id)
        {
            return await _context.Set<TEntityBase>().FindAsync(Id);
        }

        public void Update(TEntityBase obj)
        {
            _context.Set<TEntityBase>().Update(obj);
        }
    }
}
