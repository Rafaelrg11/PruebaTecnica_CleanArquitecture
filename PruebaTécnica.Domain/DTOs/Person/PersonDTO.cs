using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.DTOs.Person;

public sealed class PersonDTO
{
    public Guid IdPersona { get; set; }
    public NameDTO Name { get; set; }
    public GenrerDTO Genero { get; set; }
    public int Edad { get; set; }
    public IdentificationDTO Identificacion { get; set; }
    public AddressDTO Dirección { get; set; }
    public int Teléfono { get; set; }
}
