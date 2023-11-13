using NewRepo.Entity;
using NewRepo.Enums;

namespace NewRepo.IService
{
    public interface IProductService : ICoreService<Product>
    {
        Task<ICollection<Product>> getProductsByCategory(ProductCategory product);
    }
}
