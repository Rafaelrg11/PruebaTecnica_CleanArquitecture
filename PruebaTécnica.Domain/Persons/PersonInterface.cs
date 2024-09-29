using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.Persons;

public interface PersonInterface
{
    IEnumerable<Person> GetPersonas();
    IEnumerable<Person> GetPersona(Guid id);
    public Person CreatePersona(Person persona);
    void UpdatePersona(Guid id, Person persona);
    void DeletePersona(Guid id);
}
