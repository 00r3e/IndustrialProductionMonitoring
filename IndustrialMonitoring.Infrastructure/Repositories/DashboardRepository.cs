using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Application.DTOs;
using IndustrialMonitoring.Application.Interfaces;
using IndustrialMonitoring.Domain.Enums;
using IndustrialMonitoring.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IndustrialMonitoring.Infrastructure.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly AppDbContext _context;

        public DashboardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardSummaryDto> GetSummaryAsync()
        {
            var totalInspections = await _context.Inspections.CountAsync();

            var passedInspections = await _context.Inspections
                .CountAsync(i => i.Result == InspectionResult.Pass);

            var failedInspections = await _context.Inspections
                .CountAsync(i => i.Result == InspectionResult.Fail);

            var runningMachines = await _context.Machines
                .CountAsync(m => m.Status == MachineStatus.Running);

            var averageProcessingTime = totalInspections == 0
                ? 0
                : await _context.Inspections
                    .AverageAsync(i => (double)i.ProcessingTimeMs);

            var passRate = totalInspections == 0
                ? 0
                : (double)passedInspections / totalInspections * 100;

            return new DashboardSummaryDto
            {
                TotalInspections = totalInspections,
                PassedInspections = passedInspections,
                FailedInspections = failedInspections,
                PassRate = Math.Round(passRate, 2),
                AverageProcessingTimeMs = Math.Round(averageProcessingTime, 2),
                RunningMachines = runningMachines
            };
        }
    }
}
