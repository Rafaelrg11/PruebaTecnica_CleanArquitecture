using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Infraestructure.Configurations;

internal sealed class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("persons");

        builder.HasKey(t => t.IdPersona);

        builder.Property(t => t.Name)
            .HasMaxLength(200)
            .HasConversion(n => n.value, value => new Name(value));

        builder.Property(t => t.Genero)
            .HasMaxLength(200)
            .HasConversion(n => n.Value, value => new Genrer(value));

        builder.Property(t => t.Dirección)
            .HasMaxLength(200)
            .HasConversion(n => n.Value, value => new Address(value));

        builder.Property(t => t.Edad)
            .HasMaxLength(200)
            .HasConversion(n => n.Value, value => new Age(value));

        builder.Property(t => t.Identificacion)
            .HasMaxLength(200)
            .HasConversion(n => n.Value, value => new Identification(value));

        builder.Property(t => t.Teléfono)
            .HasMaxLength(200)
            .HasConversion(n => n.Value, value => new Phone(value));

        builder.Property<uint>("Version").IsRowVersion();

    }
}
