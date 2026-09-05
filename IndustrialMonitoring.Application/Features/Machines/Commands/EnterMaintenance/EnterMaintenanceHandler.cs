using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Application.Interfaces;

namespace IndustrialMonitoring.Application.Features.Machines.Commands.EnterMaintenance
{
    public class EnterMaintenanceHandler
    {
        private readonly IMachineRepository _repository;
        private readonly IUnitOfWork _unitOfWork;


        public EnterMaintenanceHandler(
            IMachineRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(EnterMaintenanceCommand command)
        {
            var machine = await _repository.GetByIdAsync(command.MachineId);

            if (machine is null)
            {
                throw new InvalidOperationException("Machine not found.");
            }

            machine.EnterMaintenance();

            await _repository.UpdateAsync(machine);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
