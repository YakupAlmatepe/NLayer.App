﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = 1,
                CategoryId = 1,
                Name = "Kalem1",
                Price =200,
                Stock =50,
                CreareDate= DateTime.Now
            }, new Product
            {
                Id = 2,
                CategoryId = 1,
                Name = "Kalem2",
                Price = 100,
                Stock = 150,
                CreareDate = DateTime.Now
            }, new Product
            {
                Id = 3,
                CategoryId = 1,
                Name = "Kalem3",
                Price = 239500,
                Stock = 30,
                CreareDate = DateTime.Now
            }, new Product
            {
                Id = 4,
                CategoryId = 2,
                Name = "Kitaplar1",
                Price = 200,
                Stock = 50,
                CreareDate = DateTime.Now
            }, new Product
            {
                Id = 5,
                CategoryId = 2,
                Name = "Kalem1",
                Price =450,
                Stock = 59,
                CreareDate = DateTime.Now
            }



                );
        }
    }
}
