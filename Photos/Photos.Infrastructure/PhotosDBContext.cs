using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using Photos.Domain.DataBaseEntity;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                 @"Server=(localdb)\mssqllocaldb;Database=Photos-Dev;Trusted_Connection=True;ConnectRetryCount=0");
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
