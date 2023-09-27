using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.GenericServices;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Service.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomeBaseController
    {
        private readonly IMapper _mapper;
      
        private readonly IProductService _service;
        public ProductsController(IMapper mapper, IService<Product> service, IProductService productService)
        {
            _mapper = mapper;
            _service = productService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductWithCategory()
        {
            return CreateActionResult(await _service.GetProductsWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
          //  var products = await _service.GetAllAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            //return Ok( CustomeResponseDto<List<ProductDto>>.Sucess(200, productDtos));
            return CreateActionResult(CustomeResponseDto<List<ProductDto>>.Sucess(200,productDtos));

        }
        [ServiceFilter(typeof(NotFoundFilter<Product>))]

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var products = await _service.GetByIdAsync(id);
            //  var products = await _service.GetAllAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(products);
            
         
            return CreateActionResult(CustomeResponseDto<List<ProductDto>>.Sucess(200, productDtos));

        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomeResponseDto<ProductDto>.Sucess(201, productsDto));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
             await _service.AddAsync(_mapper.Map<Product>(productDto));
           
            return CreateActionResult(CustomeResponseDto<NoContentDto>.Sucess(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);
            return CreateActionResult(CustomeResponseDto<NoContentDto>.Sucess(204));
        }
    }
}
