using DDDBasic.Application.Interfaces;
using DDDBasic.Application.Interfaces.Repository;
using DDDBasic.Domain.Entities;
using DDDBasic.Domain.Entities.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDBasic.Application.Service.Base
{
    public class Service<TIRepository, TEntityBase> : IDisposable where TIRepository : IRepository<TEntityBase> where TEntityBase : EntityBase
    {
        private readonly IUnityOfWork _uow;
        private readonly IValidator<TEntityBase> _validator;
        public Service(IUnityOfWork uow, IValidator<TEntityBase> validator)
        {
            _uow = uow;
            _validator = validator;
        }
        public void Dispose()
        {
            _uow.Dispose();
        }

        public async Task<IEnumerable<TEntityBase>> Get()
        {
            IRepository<Product> a = _uow.Products.;

            return null;
        }
    }
}
