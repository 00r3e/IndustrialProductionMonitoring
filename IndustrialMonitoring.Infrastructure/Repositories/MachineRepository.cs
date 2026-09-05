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
    public class MachineRepository : IMachineRepository
    {
        private readonly AppDbContext _context;

        public MachineRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Machine>> GetAllAsync()
        {
            return await _context.Machines.Include(machine => machine.ProductionLine).ToListAsync();
        }

        public async Task<Machine?> GetByIdAsync(int id)
        {
            return await _context.Machines.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Machine machine)
        {
            _context.Machines.Update(machine);
            return Task.CompletedTask;
        }
    }
}
