//using Microsoft.EntityFrameworkCore;
//using NLayer.Core.Models;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace NLayer.Repository
//{
//    public class AppDbContext : DbContext
//    {
//        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
//        {

//        }
//        public DbSet<Category> Categories { get; set; }
//        public DbSet<Product> Products { get; set; }
//        public DbSet<ProductFeature> ProductFeatures  { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {

//            optionsBuilder.UseSqlServer("Server=DESKTOP-QO8PCJ5;initial catalog =DbNLayer; integrated security=true;");

//            optionsBuilder.UseSqlServer(connectionString);
//            base.OnConfiguring(optionsBuilder);
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//çalışmış olduğumuz assembly üzerine işlem yapar

//            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()

//            {
//                Id = 1,
//                Color = "Kızmızı",
//                Height = 200,
//                ProductId = 1,
//            },
//            new ProductFeature()
//            {
//                Id = 2,
//                Color = "Yeşil",
//                Height = 300,
//                ProductId = 2,
//            });

//            base.OnModelCreating(modelBuilder);
//        }
//    }

//}

using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using System;
using System.Reflection;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Entity Configurations
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Seed initial data
            modelBuilder.Entity<ProductFeature>().HasData(
                new ProductFeature { Id = 1, Color = "Kızmızı", Height = 200, ProductId = 1 },
                new ProductFeature { Id = 2, Color = "Yeşil", Height = 300, ProductId = 2 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}

