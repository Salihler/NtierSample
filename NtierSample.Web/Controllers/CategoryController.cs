using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NtierSample.Core.Models;
using NtierSample.Web.ApiServices;
using NtierSample.Web.DTOs;
using NtierSample.Web.Filters;

namespace NtierSample.Web
{
    public class CategoryController : Controller
    {
        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper, CategoryApiService categoryApiService)
        {
            _mapper = mapper;
            _categoryApiService = categoryApiService;
        }
        public async Task<IActionResult> Index()
        {
            //var categories = await _categoryService.GetAllAsync();
            var categories = await _categoryApiService.GetAllAsync();
            
            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            //await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            await _categoryApiService.AddAsync(categoryDto);
            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            //var category = await _categoryService.GetByIdAsync(id);
            var categoyDto = await _categoryApiService.GetByIdAsync(id);

            return View(_mapper.Map<CategoryDto>(categoyDto));
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            //_categoryService.Update(_mapper.Map<Category>(categoryDto));
            await _categoryApiService.Update(categoryDto);

            return RedirectToAction("Index");
        }
        
        [ServiceFilter(typeof (NotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            //var category = _categoryService.GetByIdAsync(id).Result;

            //_categoryService.Remove(category);

            await _categoryApiService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}