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
    public class InspectionRepository : IInspectionRepository
    {
        private readonly AppDbContext _context;

        public InspectionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Inspection inspection)
        {
            await _context.Inspections.AddAsync(inspection);
        }

        public async Task<IReadOnlyList<Inspection>> GetAllAsync()
        {
            return await _context.Inspections
                .Include(i => i.Machine)
                .Include(i => i.Product)
                .ToListAsync();
        }
    }
}
