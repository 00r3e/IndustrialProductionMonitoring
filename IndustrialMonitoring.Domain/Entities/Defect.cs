using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Domain.Enums;

namespace IndustrialMonitoring.Domain.Entities
{
    public class Defect
    {
        public int Id { get; private set; }

        public int InspectionId { get; private set; }

        public Inspection Inspection { get; private set; } = null!;

        public DefectType Type { get; private set; }

        public string Description { get; private set; } = string.Empty;

        private Defect()
        {
        }

        internal Defect( Inspection inspection, DefectType type, string description)
        {
            ArgumentNullException.ThrowIfNull(inspection);

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException(
                    "Defect description cannot be empty.",
                    nameof(description));
            }
            Inspection = inspection;
            InspectionId = inspection.Id;

            Type = type;
            Description = description.Trim();
        }
    }
}
