using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Application.DTOs;
using IndustrialMonitoring.Application.Interfaces;

namespace IndustrialMonitoring.Application.Features.Machines.Queries.GetMachines
{
    public class GetMachinesHandler
    {
        private readonly IMachineRepository _repository;

        public GetMachinesHandler(IMachineRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<MachineDto>> HandleAsync(GetMachinesQuery query)
        {
            var machines = await _repository.GetAllAsync();

            return machines.Select(machine => new MachineDto
                        {
                            Id = machine.Id,
                            Name = machine.Name,
                            Status = machine.Status.ToString(),
                            ProductionLine = machine.ProductionLine.Name
                        })
                        .ToList();
        }
    }
}
