using DotnetCoreAPIEFCoreCosmosDB.Data;
using DotnetCoreAPIEFCoreCosmosDB.Repositories.Implementations;
using DotnetCoreAPIEFCoreCosmosDB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DotnetCoreAPIEFCoreCosmosDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ProductsDbContext>(options =>
                options.UseCosmos(
                    builder.Configuration["Cosmos:AccountEndpoint"],
                    builder.Configuration["Cosmos:AccountKey"],
                    builder.Configuration["Cosmos:DatabaseName"])
            );
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
