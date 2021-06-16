using Microsoft.Extensions.DependencyInjection;
using Photos.Infrastructure.Service;
using Photos.Infrastructure.Service.Interface;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Photos.Application.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IQRCodeService, QRCodeService>();
            services.AddTransient<IConverterService, ConverterSevice>();
            services.AddTransient<QRCodeGenerator, QRCodeGenerator>();

            return services;
        }
    }
}
