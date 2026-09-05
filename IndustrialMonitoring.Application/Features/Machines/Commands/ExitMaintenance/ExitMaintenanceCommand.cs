using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialMonitoring.Application.Features.Machines.Commands.ExitMaintenance
{
    public class ExitMaintenanceCommand
    {
        public int MachineId { get; init; }
    }
}
