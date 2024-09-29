using MediatR;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.DTOs.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Persons.UpdatePerson;

public sealed class UpdatePersonCommand : IRequest<Result>
{
    public Guid IdPersona { get; }
    public string Name { get; }
    public string Genero { get; }
    public int Edad { get; }
    public string Identificacion { get; }
    public string Dirección { get; }
    public int Teléfono { get; }

    public UpdatePersonCommand(Guid idPersona, string name, string genero, int edad, string identificacion, string dirección, int teléfono)
    {
        IdPersona = idPersona;
        Name = name;
        Genero = genero;
        Edad = edad;
        Identificacion = identificacion;
        Dirección = dirección;
        Teléfono = teléfono;
    }
}
