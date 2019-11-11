using DDDBasic.Application.Resource.Base;
using DDDBasic.Domain.Entities;
using DDDBasic.Domain.Enums;
using DDDBasic.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDBasic.Application.Resource.Response
{
    public class ProductResource : ResourceBase
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypeProduct TypeProduct { get; set; }
        public string TypeProductDescription { get; set; }
        public int SectionId { get; set; }
    }

    public static class ProductExtensions
    {
        public static ProductResource EntityToResource(this Product product)
        {
            ProductResource p = new ProductResource
            {
                Id = product.Id,
                Name = product.Name,
                Value = product.Value,
                TypeProduct = product.TypeProduct,
                TypeProductDescription = product.TypeProduct.GetDescription(),
                SectionId = product.SectionId
            };

            return p;
        }

        public static Product ResourceToEntity(this ProductResource product)
        {
            Product p = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Value = product.Value,
                TypeProduct = product.TypeProduct,
                SectionId = product.SectionId
            };

            return p;
        }
    }
}
