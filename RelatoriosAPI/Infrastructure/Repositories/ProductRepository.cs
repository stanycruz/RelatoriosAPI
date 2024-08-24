using Microsoft.EntityFrameworkCore;
using RelatoriosAPI.Domain.Entities;
using RelatoriosAPI.Domain.Interfaces;
using RelatoriosAPI.Infrastructure.Data;

namespace RelatoriosAPI.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productKey)
        {
            return await _context.Products.FindAsync(productKey);
        }
    }
}
