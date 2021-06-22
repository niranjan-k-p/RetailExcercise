using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace WingtipToys.Repositories
{
    internal class ProductsRepository : IProductsRepository
    {
        private readonly ICentralRepository _centralRepository;

        public ProductsRepository(ICentralRepository centralRepository)
        {
            _centralRepository = centralRepository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _centralRepository.EntitiesDb.Products.ToListAsync();
        }

        public async Task<List<Product>> GetProductByCategory(int categoryId)
        {
            return await _centralRepository.EntitiesDb.Products.Where(p => p.CategoryID == categoryId).ToListAsync();
        }
    }
}