using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.DTOs.Person;
using PruebaTécnica.Domain.Personas.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.Persons;

public sealed class Person : Entity
{
    public Person(
        Guid guid,
        Name name,
        Genrer genrer,
        Age age,
        Identification identification,
        Address address,
        Phone phone)
        : base(guid)
    {
        Name = name;
        Genero = genrer;
        Edad = age;
        Identificacion = identification;
        Dirección = address;
        Teléfono = phone;
    }

    private Person()
    {

    }

    public Guid IdPersona { get; private set; }
    public Name Name { get; private set; }
    public Genrer Genero { get; private set; }
    public Age Edad { get; private set; }
    public Identification Identificacion { get; private set; }
    public Address Dirección { get; private set; }
    public Phone Teléfono { get; private set; }
    public Client Cliente { get; private set; }

    public static Person Create(Name name,
        Genrer genero,
        Age edad,
        Identification identificador,
        Address direccion,
        Phone telefono)
    {
        var persona = new Person(Guid.NewGuid(), name, genero, edad, identificador, direccion, telefono);

        persona.RaiseDomainEvent(new PersonaCreatedDomainEvent(persona.Id));

        return persona;
    }

    public void UpdateName(Name name)
    {
        Name = name;
    }

    public void UpdateGenero(Genrer genero)
    {
        Genero = genero;
    }

    public void UpdateEdad(Age edad)
    {
        Edad = edad;
    }

    public void UpdateIdentificacion(Identification identificacion)
    {
        Identificacion = identificacion;
    }

    public void UpdateDirección(Address dirección)
    {
        Dirección = dirección;
    }

    public void UpdateTeléfono(Phone teléfono)
    {
        Teléfono = teléfono;
    }
}
