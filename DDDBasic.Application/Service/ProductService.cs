using DDDBasic.Application.Interfaces;
using DDDBasic.Application.Resource.Request;
using DDDBasic.Application.Validations;
using DDDBasic.Domain.Entities;
using DDDBasic.Domain.Exceptions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasic.Application.Service
{
    public class ProductService : IDisposable
    {
        private readonly IUnityOfWork _uow;
        private readonly IValidator<Product> _validator;
        public ProductService(IUnityOfWork uow, IValidator<Product> validator)
        {
            _uow = uow;
            _validator = validator;
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
            var validReturn = await _validator.ValidateAsync(product);
            if (!validReturn.IsValid)
                throw new Domain.Exceptions.ValidationException(validReturn.Errors.ToList());

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
