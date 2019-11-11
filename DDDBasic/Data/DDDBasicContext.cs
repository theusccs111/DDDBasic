using DDDBasic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDBasic.Persistence.Data
{
    public class DDDBasicContext : DbContext
    {
        public DDDBasicContext(DbContextOptions<DDDBasicContext> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Section> Section { get; set; }
    }
}
