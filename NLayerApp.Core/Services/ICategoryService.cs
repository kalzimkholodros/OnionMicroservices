using System.Threading.Tasks;
using NLayerApp.Core.Models;

namespace NLayerApp.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetSingleCategoryByIdWithProductsAsync(int categoryId);
    }
} 