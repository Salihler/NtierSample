using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NtierSample.Core.Models;
using NtierSample.Core.Repositories;
using NtierSample.Core.Services;
using NtierSample.Core.UnitOfWorks;

namespace NtierSample.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IRepository<Product> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);
        }
    }
}