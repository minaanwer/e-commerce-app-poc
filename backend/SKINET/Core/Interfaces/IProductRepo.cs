using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepo
    {
        Task<Product> GetProductAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<List<ProductBrand>> GetProductBrandsAsync();
        Task<List<ProductType>> GetProductTypesAsync();
    }
}