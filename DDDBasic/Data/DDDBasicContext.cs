using DDDBasic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                if (entity.GetProperties().Where(p => p.PropertyInfo != null).Any())
                {
                    entity.GetProperties().Where(p => p.PropertyInfo != null && p.PropertyInfo.PropertyType.Name.Equals("String")).ToList().ForEach(p => p.SetMaxLength(100));
                }

            }
        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateCreate") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DateCreate").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DateCreate").IsModified = false;
                    entry.Property("DateUpdate").CurrentValue = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync();
        }
    }
}
