using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialMonitoring.Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; }

        public string Code { get; private set; } = string.Empty;

        public string Name { get; private set; } = string.Empty;

        public ICollection<Inspection> Inspections { get; private set; } = new List<Inspection>();

        private Product()
        {
        }

        public Product(string code, string name)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException(
                    "Product code cannot be empty.",
                    nameof(code));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    "Product name cannot be empty.",
                    nameof(name));
            }
            Code = code.Trim();
            Name = name.Trim();
        }
    }
}
