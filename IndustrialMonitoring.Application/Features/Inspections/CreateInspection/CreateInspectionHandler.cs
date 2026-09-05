using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Application.Interfaces;
using IndustrialMonitoring.Domain.Entities;
using IndustrialMonitoring.Domain.Enums;

namespace IndustrialMonitoring.Application.Features.Inspections.CreateInspection
{
    public class CreateInspectionHandler
    {
        private readonly IMachineRepository _machineRepository;
        private readonly IProductRepository _productRepository;
        private readonly IInspectionRepository _inspectionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateInspectionHandler(IMachineRepository machineRepository, IProductRepository productRepository,
                                  IInspectionRepository inspectionRepository, IUnitOfWork unitOfWork)
            {
                _machineRepository = machineRepository;
                _productRepository = productRepository;
                _inspectionRepository = inspectionRepository;
                _unitOfWork = unitOfWork;
            }
        public async Task HandleAsync(CreateInspectionCommand command)
        {
            var machine = await _machineRepository.GetByIdAsync(command.MachineId);

            if (machine is null)
            {
                throw new InvalidOperationException("Machine not found.");
            }

            var product = await _productRepository.GetByIdAsync(command.ProductId);

            if (product is null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            if (machine.Status != MachineStatus.Running)
            {
                throw new InvalidOperationException(
                    "The machine must be running to create an inspection.");
            }

            if (command.ProcessingTimeMs <= 0)
            {
                throw new InvalidOperationException(
                    "Processing time must be greater than zero.");
            }

            var inspection = new Inspection(machine, product, command.Result, DateTimeOffset.UtcNow, command.ProcessingTimeMs);

            await _inspectionRepository.AddAsync(inspection);

            await _unitOfWork.SaveChangesAsync();

        }
    }

}
