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
    public class DefectConfiguration : IEntityTypeConfiguration<Defect>
    {
        public void Configure(EntityTypeBuilder<Defect> builder)
        {
            builder.ToTable("Defects");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500);
            
            builder.Property(x => x.Type)
                .IsRequired();

            builder.HasOne(x => x.Inspection)
                .WithMany(x => x.Defects)
                .HasForeignKey(x => x.InspectionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
