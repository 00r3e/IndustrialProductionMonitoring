using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Application.DTOs;
using IndustrialMonitoring.Application.Interfaces;

namespace IndustrialMonitoring.Application.Features.Inspections.GetInspections
{
    public class GetInspectionsHandler
    {
        private readonly IInspectionRepository _repository;

        public GetInspectionsHandler(IInspectionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<InspectionDto>> HandleAsync( GetInspectionsQuery query)
        {
            var inspections = await _repository.GetAllAsync();

            return inspections.Select(inspection => new InspectionDto
            {
                Id = inspection.Id,
                Machine = inspection.Machine.Name,
                Product = inspection.Product.Name,
                Result = inspection.Result.ToString(),
                ProcessingTimeMs = inspection.ProcessingTimeMs,
                Timestamp = inspection.Timestamp
            })
            .ToList();
        }
    }
}
