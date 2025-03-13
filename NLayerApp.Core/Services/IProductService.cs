using System.Collections.Generic;
using System.Threading.Tasks;
using NLayerApp.Core.Models;

namespace NLayerApp.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<List<Product>> GetProductsWithCategory();
    }
} 