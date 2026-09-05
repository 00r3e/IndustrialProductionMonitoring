using IndustrialMonitoring.Application.Features.Products.Queries.GetProduct;
using IndustrialMonitoring.Application.Features.Products.Queries.GetProducts;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialMonitoring.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly GetProductsHandler _getProductsHandler;
        private readonly GetProductHandler _getProductHandler;

        public ProductsController(
            GetProductsHandler getProductsHandler,
            GetProductHandler getProductHandler)
        {
            _getProductsHandler = getProductsHandler;
            _getProductHandler = getProductHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _getProductsHandler.HandleAsync(
                new GetProductsQuery());

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _getProductHandler.HandleAsync(
                new GetProductQuery
                {
                    Id = id
                });

            return Ok(product);
        }
    }
}
