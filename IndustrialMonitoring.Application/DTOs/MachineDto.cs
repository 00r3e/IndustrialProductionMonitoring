using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialMonitoring.Application.DTOs
{
    public sealed class MachineDto
    {
        public int Id { get; init; }

        public string Name { get; init; } = string.Empty;

        public string Status { get; init; } = string.Empty;

        public string ProductionLine { get; init; } = string.Empty;
    }
}
