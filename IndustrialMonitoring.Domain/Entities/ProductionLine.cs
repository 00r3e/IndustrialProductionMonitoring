using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialMonitoring.Domain.Entities
{
    public class ProductionLine
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public ICollection<Machine> Machines { get; private set; } = new List<Machine>();

        private ProductionLine()
        {
        }

        public ProductionLine(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    "Production line name cannot be empty.",
                    nameof(name));
            }

            Name = name.Trim();
        }
    }
}
