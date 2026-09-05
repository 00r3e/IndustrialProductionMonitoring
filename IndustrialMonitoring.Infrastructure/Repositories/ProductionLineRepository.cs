using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Application.Interfaces;
using IndustrialMonitoring.Domain.Entities;
using IndustrialMonitoring.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IndustrialMonitoring.Infrastructure.Repositories
{
    public class ProductionLineRepository : IProductionLineRepository
    {
        private readonly AppDbContext _context;

        public ProductionLineRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductionLine>> GetAllAsync()
        {
            return await _context.ProductionLines
                .ToListAsync();
        }

        public async Task<ProductionLine?> GetByIdAsync(int id)
        {
            return await _context.ProductionLines
                .FirstOrDefaultAsync(line => line.Id == id);
        }
    }
}
