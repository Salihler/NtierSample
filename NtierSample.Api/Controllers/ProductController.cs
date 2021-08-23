using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NtierSample.Api.DTOs;
using NtierSample.Api.Filters;
using NtierSample.Core.Models;
using NtierSample.Core.Services;

namespace NtierSample.Api.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithCategoriesId(int id)
        {
            var products = await _productService.GetWithCategoryByIdAsync(id);
            return Ok(_mapper.Map<ProductsWithCategoryDto>(products));
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var newProduct = await _productService.AddAsync(_mapper.Map<Product>(productDto));

            return Created(string.Empty, _mapper.Map<ProductDto>(newProduct));
        }
        
        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            //Update kısmı id boş olarak gelmesi gerektiği için, hata kontrolü yapamıyoruz. Id alanı için çözüm bulunmalı.
            _productService.Update(_mapper.Map<Product>(productDto));
            return NoContent();
        }
        
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var product = _productService.GetByIdAsync(id).Result;
            _productService.Remove(product);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult RemoveRange(IEnumerable<ProductDto> prtoductDtos)
        {
            _productService.RemoveRange(_mapper.Map<IEnumerable<Product>>(prtoductDtos));
            return NoContent();
        }
    }
}