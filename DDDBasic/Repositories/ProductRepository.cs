using DDDBasic.Application.Interfaces.Repository;
using DDDBasic.Domain.Entities;
using DDDBasic.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasic.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly DDDBasicContext _context;
        public ProductRepository(DDDBasicContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetByName(string name)
        {
            return await Get(p => p.Name.Equals(name));
        }
    }
}
