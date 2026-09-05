using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Application.DTOs;
using IndustrialMonitoring.Application.Interfaces;

namespace IndustrialMonitoring.Application.Features.ProductionLines.Queries.GetProductionLine
{
    public class GetProductionLineHandler
    {
        private readonly IProductionLineRepository _repository;

        public GetProductionLineHandler(
            IProductionLineRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductionLineDto> HandleAsync(
            GetProductionLineQuery query)
        {
            var productionLine = await _repository.GetByIdAsync(query.Id);

            if (productionLine is null)
            {
                throw new InvalidOperationException(
                    "Production line not found.");
            }

            return new ProductionLineDto
            {
                Id = productionLine.Id,
                Name = productionLine.Name
            };
        }
    }
}
