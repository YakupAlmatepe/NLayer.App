﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NLayer.Core.Sevice;

namespace NLayer.API.Controllers
{
   
    public class CategoriesController : CustomeBaseController
    {

        private readonly ICategoryService _categoryService;
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProducts(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryByIdWwithProductsAsync(categoryId));
        }
    }
}