using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialMonitoring.Application.Features.Machines.Commands.StartMachine
{
    public sealed class StartMachineCommand
    {
        public int MachineId { get; init; }
    }
}
