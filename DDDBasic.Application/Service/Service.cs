using DDDBasic.Application.Interfaces;
using DDDBasic.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDBasic.Application.Service
{
    public abstract class Service<T> where T : EntityBase
    {
        private readonly IUnityOfWork _uow;
        protected IUnityOfWork Uow { get { return _uow; } }
        public Service(IUnityOfWork uow)
        {
            _uow = uow;
        }

        public virtual T GetById(int Id)
        {
            return _uow.Repository<T>().GetFirst(e => e.Id == Id);
        }
    }
}
