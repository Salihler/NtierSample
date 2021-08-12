using System.Threading.Tasks;
using NtierSample.Core.Models;

namespace NtierSample.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}