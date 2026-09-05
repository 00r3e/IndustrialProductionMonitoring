using IndustrialMonitoring.Application.Features.ProductionLines.Queries.GetProductionLine;
using IndustrialMonitoring.Application.Features.ProductionLines.Queries.GetProductionLines;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialMonitoring.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductionLinesController : Controller
    {
        private readonly GetProductionLinesHandler _getProductionLinesHandler;
        private readonly GetProductionLineHandler _getProductionLineHandler;

        public ProductionLinesController(
            GetProductionLinesHandler getProductionLinesHandler,
            GetProductionLineHandler getProductionLineHandler)
        {
            _getProductionLinesHandler = getProductionLinesHandler;
            _getProductionLineHandler = getProductionLineHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productionLines =
                await _getProductionLinesHandler.HandleAsync(
                    new GetProductionLinesQuery());

            return Ok(productionLines);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productionLine =
                await _getProductionLineHandler.HandleAsync(
                    new GetProductionLineQuery
                    {
                        Id = id
                    });

            return Ok(productionLine);
        }
    }
}
