using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTécnica.Domain.Cuenta;
using PruebaTécnica.Domain.Movimientos;
using PruebaTécnica.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Infraestructure.Configurations;

internal sealed class MotionConfiguration : IEntityTypeConfiguration<Motion>
{
    public void Configure(EntityTypeBuilder<Motion> builder)
    {
        builder.ToTable("motions");

        builder.HasKey(m => m.IdMovimiento);

        builder.Property(t => t.TipoDeMovimiento)
            .HasMaxLength(200)
            .HasConversion(n => n.Value, value => new TypeOfMotion(value));

        builder.OwnsOne(a => a.Valor, builderc =>
        {
            builderc.Property(m => m.Amount);
        });

        builder.OwnsOne(a => a.Saldo, builderc =>
        {
            builderc.Property(m => m.Amount);
        });

        builder.Property(e => e.FechaDeMovimiento)        
            .HasColumnType("timestamp with time zone");

        builder.HasOne(m => m.Cuenta)
            .WithMany(c => c.movimientos)
            .HasForeignKey(m => m.CuentaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property<uint>("Version").IsRowVersion();
    }
}
