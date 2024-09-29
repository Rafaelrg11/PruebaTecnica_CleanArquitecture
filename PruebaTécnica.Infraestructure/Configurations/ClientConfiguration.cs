using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.Movimientos;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Infraestructure.Configurations;

internal sealed class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("clients");

        builder.HasKey(c => c.IdCliente);

        builder.Property(t => t.Contraseña)
            .HasMaxLength(50)
            .HasConversion(n => n.Value, value => new Password(value));

        builder.Property(t => t.Estado)
            .HasMaxLength(200)
            .HasConversion(n => n.Value, value => new State(value));

        builder.HasOne(x => x.Persona)
            .WithOne(a => a.Cliente)
            .HasForeignKey<Client>(e => e.PersonaId)
            .IsRequired()
            .HasConstraintName("FK_Client_Persona");

        builder.Property<uint>("Version").IsRowVersion();
    }
}
