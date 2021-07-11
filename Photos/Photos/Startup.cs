using Azure.Storage.Blobs;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Photos.Application.AssemblyMarker;
using Photos.Application.Extensions.DependencyInjection;
using Photos.Application.Queries.Photos;
using Photos.Application.Repositories;
using Photos.Domain.Repositories;
using Photos.Infrastructure;
using Photos.Infrastructure.Service;
using Photos.Infrastructure.Service.Interface;
using QRCoder;
using System.Reflection;

namespace Photos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp/build";
            //});
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist/ClientApp"; });

            services.AddPhotosDbContext();
            services.AddServices();
                        
            services.AddSingleton(x=>new BlobServiceClient(Configuration.GetValue<string>("AzureBlobStorage")));
            services.AddSingleton<IBlobService, BlobService>();
            
            services.AddMediatR(typeof(IApplicationAssemblyMarker).GetTypeInfo().Assembly);

            //TODO сделать с объектом конфига
            var redisConfig= Configuration.GetSection("Redis");

            services.AddStackExchangeRedisCache(options=> 
            {
                options.Configuration = redisConfig["Host"];
                options.InstanceName = redisConfig["DBName"];
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PhotosDBContext db)
        {
            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            db.Database.Migrate();
            

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });


            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }

            });
        }
    }
}
