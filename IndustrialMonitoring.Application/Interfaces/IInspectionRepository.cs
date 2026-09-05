using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Domain.Entities;

namespace IndustrialMonitoring.Application.Interfaces
{
    public interface IInspectionRepository
    {
        Task AddAsync(Inspection inspection);

        Task<IReadOnlyList<Inspection>> GetAllAsync();
    }
}
