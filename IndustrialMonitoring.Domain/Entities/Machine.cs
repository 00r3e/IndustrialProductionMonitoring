using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Domain.Enums;

namespace IndustrialMonitoring.Domain.Entities
{
    public class Machine
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public MachineStatus Status { get; private set; }

        public int ProductionLineId { get; private set; }

        public ProductionLine ProductionLine { get; private set; } = null!;

        public ICollection<Inspection> Inspections { get; private set; } = new List<Inspection>();

        private Machine()
        {
        }

        public Machine(string name, ProductionLine productionLine)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    "Machine name cannot be empty.",
                    nameof(name));
            }

            ArgumentNullException.ThrowIfNull(productionLine);

            Name = name.Trim();
            ProductionLine = productionLine;
            ProductionLineId = productionLine.Id;
            Status = MachineStatus.Stopped;
        }

        public void Start()
        {
            if (Status == MachineStatus.Maintenance)
            {
                throw new InvalidOperationException(
                    "A machine in maintenance cannot be started.");
            }

            Status = MachineStatus.Running;
        }

        public void Stop()
        {
            Status = MachineStatus.Stopped;
        }

        public void EnterMaintenance()
        {
            if (Status == MachineStatus.Running)
            {
                //Later, we might add a custom domain exception : InvalidMachineStateException
                throw new InvalidOperationException(
                    "A running machine must be stopped before entering maintenance.");
            }

            Status = MachineStatus.Maintenance;
        }

        public void ExitMaintenance()
        {
            if (Status != MachineStatus.Maintenance)
            {
                throw new InvalidOperationException(
                    "The machine is not currently in maintenance.");
            }

            Status = MachineStatus.Stopped;
        }
    }
}
