using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Application.DTOs;
using IndustrialMonitoring.Application.Interfaces;

namespace IndustrialMonitoring.Application.Features.Dashboard.Queries.GetDashboardSummary
{
    public class GetDashboardSummaryHandler
    {
        private readonly IDashboardRepository _repository;

        public GetDashboardSummaryHandler(IDashboardRepository repository)
        {
            _repository = repository;
        }

        public async Task<DashboardSummaryDto> HandleAsync(GetDashboardSummaryQuery query)
        {
            return await _repository.GetSummaryAsync();
        }
    }
}
