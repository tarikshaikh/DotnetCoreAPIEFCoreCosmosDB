using DotnetCoreAPIEFCoreCosmosDB.Models;
using DotnetCoreAPIEFCoreCosmosDB.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotnetCoreAPIEFCoreCosmosDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository) 
        { 
            _productRepository = productRepository;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _productRepository.GetProductAsync(id);
            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product value)
        {
            var result = await _productRepository.AddProductAsync(value);
            return Ok(result);
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Product value)
        {
            var result = await _productRepository.UpdateProductAsync(value);
            return Ok(result);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _productRepository.DeleteProductAsync(id);
            return Ok(result);
        }
    }
}
