using DDDBasic.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasic.Application.Interfaces.Repository
{
    public interface IRepository<TEntityBase> where TEntityBase : EntityBase
    {
        void Create(TEntityBase obj);
        void Update(TEntityBase obj);
        void Delete(TEntityBase obj);
        Task<TEntityBase> GetById(int Id);
        Task<IEnumerable<TEntityBase>> Get();
        Task<IEnumerable<TEntityBase>> Get(Expression<Func<TEntityBase, bool>> predicate);
    }
}
