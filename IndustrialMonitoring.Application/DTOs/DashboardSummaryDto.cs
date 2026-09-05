using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialMonitoring.Application.DTOs
{
    public class DashboardSummaryDto
    {
        public int TotalInspections { get; init; }

        public int PassedInspections { get; init; }

        public int FailedInspections { get; init; }

        public double PassRate { get; init; }

        public double AverageProcessingTimeMs { get; init; }

        public int RunningMachines { get; init; }
    }
}
