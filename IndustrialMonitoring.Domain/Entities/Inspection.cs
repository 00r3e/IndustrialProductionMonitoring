using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Domain.Enums;

namespace IndustrialMonitoring.Domain.Entities
{
    public class Inspection
    {
        private readonly List<Defect> _defects = new();
        public int Id { get; private set; }

        public int MachineId { get; private set; }

        public Machine Machine { get; private set; } = null!;

        public int ProductId { get; private set; }

        public Product Product { get; private set; } = null!;

        public InspectionResult Result { get; private set; }

        public DateTimeOffset Timestamp { get; private set; }

        public int ProcessingTimeMs { get; private set; }

        public IReadOnlyCollection<Defect> Defects => _defects;

        private Inspection()
        {
        }

        public Inspection( Machine machine, Product product, InspectionResult result, DateTimeOffset timestamp, int processingTimeMs)
        {
            ArgumentNullException.ThrowIfNull(machine);
            ArgumentNullException.ThrowIfNull(product);

            if (!Enum.IsDefined(result))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(result),
                    "Invalid inspection result.");
            }

            if (processingTimeMs <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(processingTimeMs),
                    "Processing time must be greater than zero.");
            }

            Machine = machine;
            MachineId = machine.Id;

            Product = product;
            ProductId = product.Id;

            Result = result;
            Timestamp = timestamp;
            ProcessingTimeMs = processingTimeMs;
        }

        public void AddDefect(DefectType type, string description)
        {
            if (Result == InspectionResult.Pass)
            {
                throw new InvalidOperationException(
                    "A passed inspection cannot have defects.");
            }

            var defect = new Defect(this, type, description);

            _defects.Add(defect);
        }
    }
}
