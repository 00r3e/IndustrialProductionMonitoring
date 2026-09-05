using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Domain.Entities;

namespace IndustrialMonitoring.Application.Interfaces
{
    public interface IMachineRepository
    {
        Task<Machine?> GetByIdAsync(int id);

        Task<IReadOnlyList<Machine>> GetAllAsync();

        Task UpdateAsync(Machine machine);
    }
}
