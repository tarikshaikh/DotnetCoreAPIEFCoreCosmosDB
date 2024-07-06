using DotnetCoreAPIEFCoreCosmosDB.Models;

namespace DotnetCoreAPIEFCoreCosmosDB.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductAsync(Guid id);
        Task<bool> AddProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(Guid id);
        Task<IList<Product>> GetAllProductsAsync();
    }
}