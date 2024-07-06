using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCoreAPIEFCoreCosmosDB.Data.Extensions
{
    public static class DependencyInjection
    {
        public static void AddDBClass(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ProductsDbContext>(options =>
                options.UseCosmos(
                    config["Cosmos:AccountEndpoint"],
                    config["Cosmos:AccountKey"],
                    config["Cosmos:DatabaseName"])
            );
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
