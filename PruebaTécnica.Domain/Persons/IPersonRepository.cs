using PruebaTécnica.Domain.DTOs.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.Persons;

public interface IPersonRepository
{
    Task<IEnumerable<PersonDTO>> GetPersonas();
    Task<Person> GetPersona(Guid id, CancellationToken cancellationToken);
    Task UpdatePersona(Person persona);
    Task DeletePersona(Person person);
    Task SaveChangesAsync();
}