using DDDBasic.Application.Interfaces.Repository;
using DDDBasic.Application.Resource.Request;
using DDDBasic.Domain.Entities;
using DDDBasic.Persistence.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Product>> GetProductsByAnyFilter(ProductGetRequest request)
        {
            IQueryable<Product> products = _context.Product.AsQueryable();

            if(request.SectionId != 0)
                products = _context.Product.Where(p => p.SectionId == request.SectionId);

            return await products.ToArrayAsync();
        }
    }
}
