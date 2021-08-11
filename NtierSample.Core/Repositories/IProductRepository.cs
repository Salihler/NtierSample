using System.Threading.Tasks;
using NtierSample.Core.Models;

namespace NtierSample.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}