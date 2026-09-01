using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IndustrialMonitoring.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //automatically search the assembly for every class implementing: IEntityTypeConfiguration<T>
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AppDbContext).Assembly);
        }

        public DbSet<ProductionLine> ProductionLines => Set<ProductionLine>();

        public DbSet<Machine> Machines => Set<Machine>();

        public DbSet<Product> Products => Set<Product>();

        public DbSet<Inspection> Inspections => Set<Inspection>();

        public DbSet<Defect> Defects => Set<Defect>();
    }
}
