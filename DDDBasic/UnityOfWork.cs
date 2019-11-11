using DDDBasic.Application.Interfaces;
using DDDBasic.Application.Interfaces.Repository;
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
        public IProductRepository Products { get; set; }
        public ISectionRepository Sections { get; set; }
        public ICategoryRepository Categories { get; set; }
        public UnityOfWork(DDDBasicContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Sections = new SectionRepository(_context);
            Categories = new CategoryRepository(_context);
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
