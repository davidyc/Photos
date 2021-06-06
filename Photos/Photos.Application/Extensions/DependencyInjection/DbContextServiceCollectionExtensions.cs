using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Photos.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Photos.Application.Extensions.DependencyInjection
{
    public static class DbContextServiceCollectionExtensions
    {
        public static IServiceCollection AddPhotosDbContext(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<PhotosDBContext>((services, options) =>
            {
                var configuration = services.GetRequiredService<IConfiguration>();
                options.UseSqlServer(configuration.GetConnectionString("PhotosDBContext"));
            });

            return serviceCollection;
        }
    }
}
