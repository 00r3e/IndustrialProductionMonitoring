using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Application.Interfaces;

namespace IndustrialMonitoring.Application.Features.Machines.Commands.StopMachine
{
    public class StopMachineHandler
    {
        private readonly IMachineRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public StopMachineHandler(
            IMachineRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(StopMachineCommand command)
        {
            var machine = await _repository.GetByIdAsync(command.MachineId);

            if (machine is null)
            {
                throw new InvalidOperationException("Machine not found.");
            }

            machine.Stop();

            await _repository.UpdateAsync(machine);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
