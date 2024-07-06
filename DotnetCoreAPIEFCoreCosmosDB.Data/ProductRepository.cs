using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCoreAPIEFCoreCosmosDB.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsDbContext _db;
        public ProductRepository(ProductsDbContext db) => _db = db;

        public Product GetProduct(Guid id)
        {
            var keyValues = new object[] { id };
            var product = _db.Products.Find(keyValues);
            return product;
        }

        public bool AddProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return true;
        }

        public bool UpdateProduct(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();
            return true;
        }

        public bool DeleteProduct(Guid id)
        {
            var product = GetProduct(id);

            if (product != null) 
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
                return true;
            }
            
            return false;
        }

        public IList<Product> GetAllProducts()
        {
            var allProducts = _db.Products.ToList();
            return allProducts;
        }
    }
}
