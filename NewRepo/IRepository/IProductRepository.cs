using NewRepo.Entity;
using NewRepo.Enums;

namespace NewRepo.IRepository
{
    public interface IProductRepository : ICoreRepository<Product>
    {
        Task<ICollection<Product>> getProductsByCategory(ProductCategory product);
    }
}
