using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Application.DTOs;
using IndustrialMonitoring.Application.Interfaces;

namespace IndustrialMonitoring.Application.Features.ProductionLines.Queries.GetProductionLines
{
    public class GetProductionLinesHandler
    {
        private readonly IProductionLineRepository _repository;

        public GetProductionLinesHandler(
            IProductionLineRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<ProductionLineDto>> HandleAsync(
            GetProductionLinesQuery query)
        {
            var productionLines = await _repository.GetAllAsync();

            return productionLines
                .Select(line => new ProductionLineDto
                {
                    Id = line.Id,
                    Name = line.Name
                })
                .ToList();
        }
    }
}
