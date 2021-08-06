using System.Threading.Tasks;
using NtierSample.Core.Models;

namespace NtierSample.Core.Services
{
    interface ICategortService : IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}