using DDDBasic.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasic.Application.Interfaces
{
    public interface IUnityOfWork : IDisposable
    {
        IProductRepository Products {get;}
        ISectionRepository Sections { get;}
        ICategoryRepository Categories { get;}
        Task CompleteAsync();
    }
}
