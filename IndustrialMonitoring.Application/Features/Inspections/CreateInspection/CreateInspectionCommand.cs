using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Domain.Enums;

namespace IndustrialMonitoring.Application.Features.Inspections.CreateInspection
{
    public sealed class CreateInspectionCommand
    {
        public int MachineId { get; init; }

        public int ProductId { get; init; }

        public InspectionResult Result { get; init; }

        public int ProcessingTimeMs { get; init; }
    }
}
