using System.Collections.Generic;
using System.Threading.Tasks;

namespace WingtipToys.Repositories
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAllProducts();

        Task<List<Product>> GetProductByCategory(int categoryId);
    }
}