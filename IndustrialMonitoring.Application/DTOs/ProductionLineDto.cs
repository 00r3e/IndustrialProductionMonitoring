using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialMonitoring.Application.DTOs
{
    public sealed class ProductionLineDto
    {
        public int Id { get; init; }

        public string Name { get; init; } = string.Empty;
    }
}
