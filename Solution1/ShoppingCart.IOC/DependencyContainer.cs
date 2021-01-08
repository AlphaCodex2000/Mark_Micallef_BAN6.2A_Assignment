using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Application.AutoMapper;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.Data.Context;
using ShoppingCart.Data.Repositories;
using ShoppingCart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.IOC
{
    public class DependencyContainer
    {

        //the dependency Container is called when the application(website) starts and does the associations that follow in the method RegisterServices.
        //why?
        //so whenever there's another call that demands an instance of class (interface) which has been recognized in the method RegisterServices,
        //The RegisterServices method, creates an instance of that on demand "class"
        //and we are also informing the RegisterServices about the associations that exist between interface - class + implementation

        //what AddScoped mean?

        /*
         * 
         */
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ShoppingCartDbContext>(options =>
                options.UseSqlServer(
                    connectionString));

            services.AddScoped<iProductRepository, ProductsRepository>();
            services.AddScoped<IProductService, ProductsService>();

            services.AddScoped<iCategoryRepository, CategoriesRepository>();
            services.AddScoped<iCategoryService, CategoriesService>();

            services.AddScoped<iMembersRepository, MembersRepository>();
            services.AddScoped<IMemberService, MembersService>();

            services.AddAutoMapper(typeof(AutoMapperConfiguration));
            AutoMapperConfiguration.RegisterMappings();
            
        }
    }
}
