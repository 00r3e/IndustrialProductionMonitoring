using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Application.DTOs;

namespace IndustrialMonitoring.Application.Interfaces
{
    public interface IDashboardRepository
    {
        Task<DashboardSummaryDto> GetSummaryAsync();
    }
}
