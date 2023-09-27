using NLayer.Core.DTOs;
using NLayer.Core.GenericServices;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Sevice
{
    public interface ICategoryService : IService<Category>
    {
        public  Task<CustomeResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWwithProductsAsync(int categoryId);
    }
}
