using AdvertisementApp.Business.ValidationRules;
using AdvertisementApp.DataAccess.Contexts;
using AdvertisementApp.Dtos.ProvidedServiceDtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services,IConfiguration configuration)
        {

      
            services.AddDbContext<AdvertisementContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Local"));
            });

            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();
        }
    }
}
