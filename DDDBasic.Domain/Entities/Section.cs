using DDDBasic.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDBasic.Domain.Entities
{
    public class Section : EntityBase
    {
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
