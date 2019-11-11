using DDDBasic.Application.Interfaces;
using DDDBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasic.Application.Service
{
    public class ProductService : IDisposable
    {
        private readonly IUnityOfWork _uow;
        public ProductService(IUnityOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _uow.Products.Get();
        }
        public async Task AddProduct(Product product)
        {
            _uow.Products.Create(product);
            await _uow.CompleteAsync();
        }
        public async Task DeleteProduct(Product product)
        {
            _uow.Products.Delete(product);
            await _uow.CompleteAsync();
        }
        public async Task UpdateProduct(Product product)
        {
            _uow.Products.Update(product);
            await _uow.CompleteAsync();
        }
        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            return await _uow.Products.GetByName(name);
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
