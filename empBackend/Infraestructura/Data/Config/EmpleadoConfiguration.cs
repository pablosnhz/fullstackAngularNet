using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Config
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Apellidos).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Nombres).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Cargo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompaniaId).IsRequired();

            // TODO Relaciones
            // conexion de uno a muchos
            builder.HasOne(x => x.Compania).WithMany().HasForeignKey(x => x.CompaniaId);
        }
    }
}