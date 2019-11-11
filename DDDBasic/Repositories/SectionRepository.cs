using DDDBasic.Application.Interfaces.Repository;
using DDDBasic.Domain.Entities;
using DDDBasic.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDBasic.Persistence.Repositories
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        public SectionRepository(DDDBasicContext context) : base(context)
        {
        }
    }
}
