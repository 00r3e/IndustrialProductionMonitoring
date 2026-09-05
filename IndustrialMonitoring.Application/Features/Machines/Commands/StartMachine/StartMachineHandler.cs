using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Application.Interfaces;

namespace IndustrialMonitoring.Application.Features.Machines.Commands.StartMachine
{

    public class StartMachineHandler
    {
        private readonly IMachineRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public StartMachineHandler(IMachineRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(StartMachineCommand command)
        {
            var machine = await _repository.GetByIdAsync(command.MachineId);

            if (machine is null)
            {
                throw new InvalidOperationException("Machine not found.");
            }

            machine.Start();

            await _repository.UpdateAsync(machine);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
