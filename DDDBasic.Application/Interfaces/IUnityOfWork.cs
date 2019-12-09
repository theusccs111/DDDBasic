using DDDBasic.Application.Interfaces.Repository;
using DDDBasic.Domain.Entities;
using DDDBasic.Domain.Entities.Base;
using System;
using System.Threading.Tasks;

namespace DDDBasic.Application.Interfaces
{
    public interface IUnityOfWork : IDisposable
    {
        IRepository<Product> Products {get;}
        IRepository<Section> Sections { get;}
        IRepository<Category> Categories { get;}
        Task CompleteAsync();
        IRepository<T> Repository<T>() where T : EntityBase;
    }
}
