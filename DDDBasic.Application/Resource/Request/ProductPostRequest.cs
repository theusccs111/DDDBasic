using DDDBasic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDBasic.Application.Resource.Request
{
    public class ProductPostRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypeProduct TypeProduct { get; set; }
        public int SectionId { get; set; }
    }
}
