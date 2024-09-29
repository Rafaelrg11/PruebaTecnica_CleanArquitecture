using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTécnica.Domain.Accounts;
using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.Cuenta;
using PruebaTécnica.Domain.Cuentas;
using PruebaTécnica.Domain.Persons;
using PruebaTécnica.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Infraestructure.Configurations;

internal class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("account");

        builder.HasKey(t => t.IdCuenta);

        builder.Property(t => t.NumeroCuenta)
            .HasMaxLength(50)
            .HasConversion(n => n.Value, value => new NumberOfAccount(value));

        builder.OwnsOne(a => a.Saldo, builderc =>
        {
            builderc.Property(m => m.Amount);
        });

        builder.Property(t => t.Estado)
            .HasMaxLength(50)
            .HasConversion(n => n.status, value => new AccountStatus(value));

        builder.Property(t => t.TipoDeCuenta)
            .HasMaxLength(50)
            .HasConversion(n => n.Value, value => new TypeOfAccount(value));

        builder.HasOne(m => m.Cliente)
            .WithMany(c => c.Accounts)
            .HasForeignKey(m => m.IdCliente)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.movimientos)
           .WithOne(m => m.Cuenta)
           .HasForeignKey(m => m.CuentaId)
           .OnDelete(DeleteBehavior.Cascade);

        builder.Property<uint>("Version").IsRowVersion();
    }
}
