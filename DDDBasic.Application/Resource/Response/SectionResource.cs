using DDDBasic.Application.Resource.Base;
using DDDBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDBasic.Application.Resource.Response
{
    public class SectionResource : ResourceBase
    {
        public virtual CategoryResource Category { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<ProductResource> Products { get; set; }
    }

    public static class SectionExtensions
    {
        public static SectionResource EntityToResource(this Section section)
        {
            SectionResource s = new SectionResource
            {
                Id = section.Id,
                CategoryId = section.CategoryId,
                Category = section.Category.EntityToResource(),
                Products = section.Products.Select(p => p.EntityToResource()).ToArray(),
            };

            return s;
        }

        public static Section ResourceToEntity(this SectionResource section)
        {
            Section s = new Section
            {
                Id = section.Id,
                CategoryId = section.CategoryId,
                Category = section.Category.ResourceToEntity(),
                Products = section.Products.Select(p => p.ResourceToEntity()).ToArray(),
            };

            return s;
        }
    }
}
