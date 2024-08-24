using RelatoriosAPI.Domain.Entities;

namespace RelatoriosAPI.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productKey);
    }
}
