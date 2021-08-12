using System.Threading.Tasks;
using NtierSample.Core.Models;
using NtierSample.Core.Repositories;
using NtierSample.Core.Services;
using NtierSample.Core.UnitOfWorks;

namespace NtierSample.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IRepository<Category> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _unitOfWork.Categories.GetWithProductsByIdAsync(categoryId);
        }
    }
}