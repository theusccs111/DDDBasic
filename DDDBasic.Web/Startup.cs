
using DDDBasic.Application.Interfaces;
using DDDBasic.Application.Interfaces.Repository;
using DDDBasic.Application.Service;
using DDDBasic.Application.Validations;
using DDDBasic.Domain.Entities;
using DDDBasic.Persistence;
using DDDBasic.Persistence.Data;
using DDDBasic.Persistence.Repositories;
using DDDBasic.Web.Filters;
using DDDBasic.Web.Mapping;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;

namespace DDDBasic.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DDDBasicContext>(options => options.UseSqlServer(connectionString));

            InjectFluentValidation(services);
            InjectServices(services);
            InjectRepositories(services);

            services
               .AddMvc(options => {
                   options.Filters.Add(typeof(CustomExceptionFilterAttribute));
                   options.EnableEndpointRouting = false;
               })
               .AddFluentValidation();
        }

        private static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<ProductService>();
            //services.AddScoped<SectionService>();
            //services.AddScoped<CategoryService>();
        }

        private static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();


            services.AddScoped<IUnityOfWork, UnityOfWork>();
        }


        private static void InjectFluentValidation(IServiceCollection services)
        {
            services.AddTransient<IValidator<Product>, ProductValidator>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
