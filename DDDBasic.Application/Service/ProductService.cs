using DDDBasic.Application.Interfaces;
using DDDBasic.Domain.Entities;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDBasic.Application.Service
{
    public class ProductService : Service<Product>
    {
        private readonly IValidator<Product> _validator;

        public ProductService(IUnityOfWork uow, IValidator<Product> validator) : base(uow)
        {
            _validator = validator;
        }
        
        public async Task Add(Product product)
        {
            var validReturn = await _validator.ValidateAsync(product);
            if (!validReturn.IsValid)
                throw new Domain.Exceptions.ValidationException(validReturn.Errors.ToList());

            Uow.Products.Create(product);
            await Uow.CompleteAsync();
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
            Uow.Products.Delete(product);
            await Uow.CompleteAsync();
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
            Uow.Products.Update(product);
            await Uow.CompleteAsync();
        }
        public async Task UpdateMany(Product[] products)
        {
            foreach (var item in products)
            {
                await Update(item);
            }
        }

        public IEnumerable<Product> Get()
        {
            return Uow.Products.GetAll().ToArray();
        }

        public IEnumerable<Product> GetProductsByName(string name)
        {
            return Uow.Products.Get(p => p.Name.Trim().ToUpper().Equals(name.Trim().ToUpper())).ToArray();
        }

    }
}
