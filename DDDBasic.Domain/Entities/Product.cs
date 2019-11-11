using DDDBasic.Domain.Entities.Base;
using DDDBasic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDBasic.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypeProduct TypeProduct { get; set; }
        public int SectionId { get; set; }
    }
}
