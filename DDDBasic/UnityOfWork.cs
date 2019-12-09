using DDDBasic.Application.Interfaces;
using DDDBasic.Application.Interfaces.Repository;
using DDDBasic.Domain.Entities;
using DDDBasic.Domain.Entities.Base;
using DDDBasic.Persistence.Data;
using DDDBasic.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasic.Persistence
{
    public class UnityOfWork : IUnityOfWork, IDisposable
    {
        private readonly DDDBasicContext _context;
        //private Dictionary<string, object> repositories;

        public IRepository<Product> Products { get { return new Repository<Product>(_context); } }
        public IRepository<Section> Sections { get { return new Repository<Section>(_context); } }
        public IRepository<Category> Categories { get { return new Repository<Category>(_context); } }
        public UnityOfWork(DDDBasicContext context)
        {
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        //não apagar talvez use
        //public IRepository<TEntity> Repository<TEntity>() where TEntity : EntityBase
        //{
        //    if (repositories == null)
        //    {
        //        repositories = new Dictionary<string, object>();
        //    }

        //    var type = typeof(TEntity).Name;
        //    if (!repositories.ContainsKey(type))
        //    {
        //        var repositorioType = typeof(Repository<>);
        //        var repositorioInstancia = Activator.CreateInstance(repositorioType.MakeGenericType(typeof(TEntity)), _context);
        //        repositories.Add(type, repositorioInstancia);
        //    }

        //    return (Repository<TEntity>)repositories[type];
        //}
    }
}
