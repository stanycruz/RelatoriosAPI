using RelatoriosAPI.Domain.Entities;
using RelatoriosAPI.Domain.Interfaces;
using RelatoriosAPI.Domain.Services;

namespace RelatoriosAPI.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productKey)
        {
            return await _productRepository.GetProductByIdAsync(productKey);
        }
    }
}
