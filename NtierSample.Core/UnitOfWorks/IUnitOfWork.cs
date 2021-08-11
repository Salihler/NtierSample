using System.Threading.Tasks;
using NtierSample.Core.Repositories;

namespace NtierSample.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        Task CommitAsync();
        void Commit();
    }
}