using Microsoft.EntityFrameworkCore;
using NewRepo.Context;
using NewRepo.Entity;
using NewRepo.Enums;
using NewRepo.IRepository;

namespace NewRepo.Repository
{
    class ProductRepository : CoreRepository<Product>, IProductRepository
    {
        public ProductRepository(CoreContext context) :base(context)
        {

        }
        public async Task<ICollection<Product>> getProductsByCategory(ProductCategory category)
        {
            return await 
                _context.products.
                Where(product => product.category.Equals(category)).
                ToListAsync();
        }
    }
}
