using DDDBasic.Application.Interfaces.Repository;
using DDDBasic.Domain.Entities;
using DDDBasic.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDBasic.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DDDBasicContext context) : base(context)
        {
        }
    }
}
