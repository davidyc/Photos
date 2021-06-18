using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using Photos.Domain.DataBaseEntity;
using Microsoft.Extensions.Configuration ;

namespace Photos.Infrastructure
{
    public class PhotosDBContext : DbContext
    {
        public PhotosDBContext()
        {

        }

        public PhotosDBContext(DbContextOptions<PhotosDBContext> options) : base(options)
        {

        }

        public DbSet<TestEntity> Test { get; set; }
        public DbSet<PhotoEntity> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                //.AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{envName}.json", optional: false)
                .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("PhotosDBContext"));
            }
        

            base.OnConfiguring(optionsBuilder);
        }
    }
}
