using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCoreAPIEFCoreCosmosDB.Data
{
    public interface IProductRepository
    {
        Product GetProduct(Guid id);
        bool AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(Guid id);
        IList<Product> GetAllProducts();
    }
}
