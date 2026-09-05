using IndustrialMonitoring.Application.Features.Dashboard.Queries.GetDashboardSummary;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialMonitoring.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {

        private readonly GetDashboardSummaryHandler _handler;

        public DashboardController(
            GetDashboardSummaryHandler handler)
        {
            _handler = handler;
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary()
        {
            var summary = await _handler.HandleAsync(new GetDashboardSummaryQuery());

            return Ok(summary);
        }
    }
}
