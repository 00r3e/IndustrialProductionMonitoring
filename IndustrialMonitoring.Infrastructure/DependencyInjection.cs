
using IndustrialMonitoring.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IndustrialMonitoring.Application.Interfaces;
using IndustrialMonitoring.Infrastructure.Repositories;
using IndustrialMonitoring.Application.Features.Machines.Commands.StartMachine;
using IndustrialMonitoring.Application.Features.Machines.Commands.StopMachine;
using IndustrialMonitoring.Application.Features.Machines.Commands.EnterMaintenance;
using IndustrialMonitoring.Application.Features.Machines.Commands.ExitMaintenance;
using IndustrialMonitoring.Application.Features.Machines.Queries.GetMachines;
using IndustrialMonitoring.Application.Features.Inspections.CreateInspection;
using IndustrialMonitoring.Application.Features.Inspections.GetInspections;
using IndustrialMonitoring.Application.Features.Dashboard.Queries.GetDashboardSummary;
using IndustrialMonitoring.Application.Features.Products.Queries.GetProducts;
using IndustrialMonitoring.Application.Features.ProductionLines.Queries.GetProductionLines;
using IndustrialMonitoring.Application.Features.Products.Queries.GetProduct;
using IndustrialMonitoring.Application.Features.ProductionLines.Queries.GetProductionLine;

namespace IndustrialMonitoring.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString =
                configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<StartMachineHandler>(); 
            services.AddScoped<StopMachineHandler>();
            services.AddScoped<EnterMaintenanceHandler>();
            services.AddScoped<ExitMaintenanceHandler>();
            services.AddScoped<GetMachinesHandler>();
            services.AddScoped<CreateInspectionHandler>();
            services.AddScoped<GetInspectionsHandler>();
            services.AddScoped<GetDashboardSummaryHandler>();
            services.AddScoped<GetProductsHandler>();
            services.AddScoped<GetProductionLinesHandler>();
            services.AddScoped<GetProductHandler>();
            services.AddScoped<GetProductionLineHandler>();


            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IInspectionRepository, InspectionRepository>();

            services.AddScoped<IMachineRepository, MachineRepository>();

            services.AddScoped<IDashboardRepository, DashboardRepository>();

            services.AddScoped<IProductionLineRepository, ProductionLineRepository>();


            return services;
        }
    }
}
