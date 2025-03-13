using System.Threading.Tasks;
using NLayerApp.Core.Models;

namespace NLayerApp.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetSingleCategoryByIdWithProductsAsync(int categoryId);
    }
} 