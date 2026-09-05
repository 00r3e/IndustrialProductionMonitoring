using Microsoft.AspNetCore.Mvc;
using IndustrialMonitoring.Application.Features.Machines.Commands.StartMachine;
using IndustrialMonitoring.Application.Features.Machines.Commands.StopMachine;
using IndustrialMonitoring.Application.Features.Machines.Commands.EnterMaintenance;
using IndustrialMonitoring.Application.Features.Machines.Commands.ExitMaintenance;
using IndustrialMonitoring.Application.Features.Machines.Queries.GetMachines;

namespace IndustrialMonitoring.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MachinesController : ControllerBase
    {
        private readonly StartMachineHandler _startMachineHandler;
        private readonly StopMachineHandler _stopMachineHandler;
        private readonly EnterMaintenanceHandler _enterMaintenanceHandler;
        private readonly ExitMaintenanceHandler _exitMaintenanceHandler;
        private readonly GetMachinesHandler _getMachinesHandler;

        public MachinesController(StartMachineHandler startMachineHandler, StopMachineHandler stopMachineHandler, 
            EnterMaintenanceHandler enterMaintenanceHandler, ExitMaintenanceHandler exitMaintenanceHandler,
            GetMachinesHandler getMachinesHandler)
        {
            _startMachineHandler = startMachineHandler;
            _stopMachineHandler = stopMachineHandler;
            _enterMaintenanceHandler = enterMaintenanceHandler;
            _exitMaintenanceHandler = exitMaintenanceHandler;
            _getMachinesHandler = getMachinesHandler;
        }

        [HttpPost("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            await _startMachineHandler.HandleAsync(
                new StartMachineCommand
                {
                    MachineId = id
                });

            return NoContent();
        }

        [HttpPost("{id}/stop")]
        public async Task<IActionResult> Stop(int id)
        {
            await _stopMachineHandler.HandleAsync(
                new StopMachineCommand
                {
                    MachineId = id
                });

            return NoContent();
        }

        [HttpPost("{id}/maintenance")]
        public async Task<IActionResult> EnterMaintenance(int id)
        {
            await _enterMaintenanceHandler.HandleAsync(
                new EnterMaintenanceCommand
                {
                    MachineId = id
                });

            return NoContent();
        }

        [HttpPost("{id}/exit-maintenance")]
        public async Task<IActionResult> ExitMaintenance(int id)
        {
            await _exitMaintenanceHandler.HandleAsync(
                new ExitMaintenanceCommand
                {
                    MachineId = id
                });

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getMachinesHandler.HandleAsync(new GetMachinesQuery());

            return Ok(result);
        }
    }
}
