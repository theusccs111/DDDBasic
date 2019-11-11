using DDDBasic.Application.Resource.Base;
using DDDBasic.Domain.Entities;

namespace DDDBasic.Application.Resource.Response
{
    public class CategoryResource : ResourceBase
    {
        public string Description { get; set; }
    }

    public static class CategoryExtensions
    {
        public static CategoryResource EntityToResource(this Category category)
        {
            CategoryResource c = new CategoryResource
            {
                Id = category.Id,
                Description = category.Description,
            };

            return c;
        }

        public static Category ResourceToEntity(this CategoryResource category)
        {
            Category c = new Category
            {
                Id = category.Id,
                Description = category.Description,
            };

            return c;
        }
    }
}
