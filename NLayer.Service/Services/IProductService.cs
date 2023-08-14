﻿using NLayer.Core.DTOs;
using NLayer.Core.GenericServices;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public interface IProductService : IService<Product>
    {
        Task<CustomeResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory();
    }
}