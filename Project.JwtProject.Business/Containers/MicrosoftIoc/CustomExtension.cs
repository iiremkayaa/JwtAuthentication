using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Project.JwtProject.Business.Concrete;
using Project.JwtProject.Business.Interfaces;
using Project.JwtProject.Business.ValidationRules.FluentValidation;
using Project.JwtProject.DataAccess.Concrete.Repositories;
using Project.JwtProject.DataAccess.Interfaces;
using Project.JwtProject.Entities.Dtos.AppUserDtos;
using Project.JwtProject.Entities.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.JwtProject.Business.Containers.MicrosoftIoc
{
    public static class CustomExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped<IProductDal,EfProductRepository>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IAppUserDal,EfAppUserRepository>();
            services.AddScoped<IAppUserService,AppUserManager>();
            services.AddScoped<IAppRoleDal,EfAppRoleRepository>();
            services.AddScoped<IAppRoleService,AppRoleManager>();
            services.AddScoped<IAppUserRoleDal,EfAppUserRoleRepository>();
            services.AddScoped<IAppUserRoleService,AppUserRoleManager>();
            services.AddTransient<IValidator<ProductAddDto>, ProductAddDtoValidator>();
            services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateDtoValidator>();
            services.AddScoped<IJwtService, JwtManager>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddDtoValidator>();


        }
    }
}
