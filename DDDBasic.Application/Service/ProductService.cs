using DDDBasic.Application.Interfaces;
using DDDBasic.Application.Resource.Request;
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

        public async Task<IEnumerable<Product>> Get()
        {
            return await _uow.Products.Get();
        }

        public async Task<Product> GetById(int Id)
        {
            return await _uow.Products.GetById(Id);
        }

        public async Task<IEnumerable<Product>> GetByAnyFilter(ProductGetRequest request)
        {
            return await _uow.Products.GetProductsByAnyFilter(request);
        }

        public async Task Add(Product product)
        {
            _uow.Products.Create(product);
            await _uow.CompleteAsync();
        }

        public async Task AddMany(Product[] products)
        {
            foreach (var item in products)
            {
                await Add(item);
            }
        }

        public async Task Delete(Product product)
        {
            _uow.Products.Delete(product);
            await _uow.CompleteAsync();
        }
        
        public async Task DeleteMany(Product[] products)
        {
            foreach (var item in products)
            {
                await Delete(item);
            }
        }

        public async Task Update(Product product)
        {
            _uow.Products.Update(product);
            await _uow.CompleteAsync();
        }
        public async Task UpdateMany(Product[] products)
        {
            foreach (var item in products)
            {
                await Update(item);
            }
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
