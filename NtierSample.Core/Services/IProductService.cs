using System.Threading.Tasks;
using NtierSample.Core.Models;

namespace NtierSample.Core.Services
{
    interface IProductService : IService<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);

        // bool ControlInnerBarcode(Product product);
    }
}