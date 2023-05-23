using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepo
    {
        Task<Product> GetProductAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
    }
}