using NewRepo.Entity;
using NewRepo.Enums;
using NewRepo.IRepository;
using NewRepo.IService;

namespace NewRepo.Service
{
    class ProductCrudService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductCrudService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> GetById(long productId)
        {
            return await _productRepository.GetById(productId);
        }
        public async Task Insert(Product product)
        {
            await _productRepository.Insert(product);
        }

        public async Task Update(long productId, Product product)
        {
            await _productRepository.Update(productId, product);
        }
        public async Task Delete(long id)
        {
            await _productRepository.Delete(id);
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }
        public Task<ICollection<Product>> getProductsByCategory(ProductCategory product)
        {
            throw new NotImplementedException();
        }
    }
}
