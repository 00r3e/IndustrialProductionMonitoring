using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialMonitoring.Application.DTOs
{
    public sealed class InspectionDto
    {
        public int Id { get; init; }

        public string Machine { get; init; } = string.Empty;

        public string Product { get; init; } = string.Empty;

        public string Result { get; init; } = string.Empty;

        public int ProcessingTimeMs { get; init; }

        public DateTimeOffset Timestamp { get; init; }
    }
}
