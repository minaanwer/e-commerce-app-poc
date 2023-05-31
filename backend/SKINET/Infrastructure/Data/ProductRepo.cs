using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{

    public class ProductRepo : IProductRepo
    {
        private readonly StoreContext _context;
        public ProductRepo(StoreContext context)
        {
            _context = context;
        }

      
      

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products.Include(x=>x.ProductTypeId).Include(x=>x.ProductBrandId).ToListAsync();
        }

        public async Task<List<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<List<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products.Include(x => x.ProductTypeId).Include(x => x.ProductBrandId).FirstOrDefaultAsync(x=>x.Id==id);
        }

    }
}
