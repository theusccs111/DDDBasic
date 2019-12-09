using DDDBasic.Application.Interfaces.Repository;
using DDDBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasic.Application.Interfaces
{
    public interface IUnityOfWork : IDisposable
    {
        IRepository<Product> Products {get;}
        IRepository<Section> Sections { get;}
        IRepository<Category> Categories { get;}
        Task CompleteAsync();
    }
}
