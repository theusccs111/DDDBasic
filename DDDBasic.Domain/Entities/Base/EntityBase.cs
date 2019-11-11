using System;
using System.Collections.Generic;
using System.Text;

namespace DDDBasic.Domain.Entities.Base
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
