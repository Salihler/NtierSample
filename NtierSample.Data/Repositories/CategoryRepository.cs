using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NtierSample.Core.Models;
using NtierSample.Core.Repositories;

namespace NtierSample.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext appDbContext {get => _context as AppDbContext;}
        public CategoryRepository(DbContext context) : base(context)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await appDbContext.Categories.Include(x => x.Products).SingleOrDefaultAsync(x => x.Id == categoryId);
        }
    }
}