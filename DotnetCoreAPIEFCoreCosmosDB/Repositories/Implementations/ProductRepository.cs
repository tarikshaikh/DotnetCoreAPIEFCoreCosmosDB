using DotnetCoreAPIEFCoreCosmosDB.Data;
using DotnetCoreAPIEFCoreCosmosDB.Models;
using DotnetCoreAPIEFCoreCosmosDB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DotnetCoreAPIEFCoreCosmosDB.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsDbContext _db;
        public ProductRepository(ProductsDbContext db) => _db = db;

        public async Task<Product> GetProductAsync(Guid id)
        {
            try
            {
                var keyValues = new object[] { id };
                var product = await _db.Products.FindAsync(keyValues);
                return product;
            }
            catch (Exception)
            {
                // Log the exception
                return null;
            }
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            try
            {
                _db.Products.Add(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // Log the exception
                return false;
            }
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            try
            {
                _db.Products.Update(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // Log the exception
                return false;
            }
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            try
            {
                var product = await GetProductAsync(id);

                if (product != null)
                {
                    _db.Products.Remove(product);
                    await _db.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                // Log the exception
                return false;
            }
        }

        public async Task<IList<Product>> GetAllProductsAsync()
        {
            try
            {
                var allProducts = await _db.Products.ToListAsync();
                return allProducts;
            }
            catch (Exception)
            {
                // Log the exception
                return null;
            }
        }
    }
}
