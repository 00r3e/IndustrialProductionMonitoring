using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialMonitoring.Application.Features.Machines.Commands.EnterMaintenance
{
    public sealed class EnterMaintenanceCommand
    {
        public int MachineId { get; init; }
    }
}
