using System.Threading.Tasks;
using NtierSample.Core.Models;

namespace NtierSample.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}