using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IndustrialMonitoring.Infrastructure.Data.Seed
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            await SeedProductionLinesAsync(context);

            await SeedProductsAsync(context);

            await SeedMachinesAsync(context);

            await context.SaveChangesAsync();
        }
        private static async Task SeedProductionLinesAsync(AppDbContext context)
        {
            if (await context.ProductionLines.AnyAsync())
                return;

            var productionLines = new[]
            {
                new ProductionLine("Line A"),
                new ProductionLine("Line B")
            };

            await context.ProductionLines.AddRangeAsync(productionLines);

        }

        private static async Task SeedProductsAsync(AppDbContext context)
        {
            if (await context.Products.AnyAsync())
                return;

            var products = new[]
            {
                new Product("PRD-1001", "Bottle Cap"),
                new Product("PRD-1002", "Plastic Bottle"),
                new Product("PRD-1003", "Bottle Label")
            };

            await context.Products.AddRangeAsync(products);

        }

        private static async Task SeedMachinesAsync(AppDbContext context)
        {
            if (await context.Machines.AnyAsync())
                return;

            var lineA = await context.ProductionLines
                .FirstAsync(x => x.Name == "Line A");

            var lineB = await context.ProductionLines
                .FirstAsync(x => x.Name == "Line B");

            var machines = new[]
            {
                new Machine(
                    "Camera Inspection 1",
                    lineA),

                new Machine(
                    "Camera Inspection 2",
                    lineA),

                new Machine(
                    "Robot Arm 1",
                    lineB),

                new Machine(
                    "Packaging Machine",
                    lineB)
            };

            await context.Machines.AddRangeAsync(machines);

        }
    }
}
