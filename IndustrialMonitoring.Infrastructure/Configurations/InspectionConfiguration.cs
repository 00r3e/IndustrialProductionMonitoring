using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndustrialMonitoring.Infrastructure.Configurations
{
    public class InspectionConfiguration : IEntityTypeConfiguration<Inspection>
    {
        public void Configure(EntityTypeBuilder<Inspection> builder)
        {
            builder.ToTable("Inspections");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Timestamp)
                .IsRequired();

            builder.Property(x => x.Result)
                .IsRequired();

            builder.Property(x => x.ProcessingTimeMs)
                .IsRequired();

            builder.HasOne(x => x.Machine)
                .WithMany(x => x.Inspections)
                .HasForeignKey(x => x.MachineId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Inspections)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
