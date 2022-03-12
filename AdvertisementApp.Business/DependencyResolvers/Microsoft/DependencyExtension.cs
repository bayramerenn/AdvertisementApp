﻿using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Business.Mappings.AutoMapper;
using AdvertisementApp.Business.Services;
using AdvertisementApp.Business.ValidationRules;
using AdvertisementApp.DataAccess.Contexts;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdvertisementApp.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Local"));
            });
            services.AddScoped<IUow,Uow>();

            services.AddAutoMapper(
                typeof(ProvidedServiceProfile),
                typeof(AdvertisementProfile),
                typeof(AppUserProfile),
                typeof(GenderProfile),
                typeof(AppRoleProfile),
                typeof(AdvertisementAppUserProfile),
                typeof(AdvertisementAppUserStatusProfile),
                typeof(MilitaryStatusProfile)
                                );

            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>();
            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementAppUserCreateDto>, AdvertisementAppUserCreateDtoValidator>();

            services.AddScoped<IProvidedServiceService, ProvidedServiceManager>();
            
            services.AddScoped<IAdvertisementService, AdvertisementManager>();
            //services.AddScoped<IAppUserService, AppUserService>();
            //services.AddScoped<IGenderService, GenderService>();
            //services.AddScoped<IAdvertisementAppUserService, AdvertisementAppUserService>();
        }
    }
}