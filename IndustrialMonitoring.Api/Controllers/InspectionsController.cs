using IndustrialMonitoring.Application.Features.Inspections.CreateInspection;
using IndustrialMonitoring.Application.Features.Inspections.GetInspections;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialMonitoring.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InspectionsController : ControllerBase
    {
        private readonly CreateInspectionHandler _createInspectionHandler;
        private readonly GetInspectionsHandler _getInspectionsHandler;

        public InspectionsController(CreateInspectionHandler createInspectionHandler, GetInspectionsHandler getInspectionsHandler)
        {
            _createInspectionHandler = createInspectionHandler;
            _getInspectionsHandler = getInspectionsHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInspectionCommand command)
        {
            await _createInspectionHandler.HandleAsync(command);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var inspections = await _getInspectionsHandler.HandleAsync(
                new GetInspectionsQuery());

            return Ok(inspections);
        }
    }
}
