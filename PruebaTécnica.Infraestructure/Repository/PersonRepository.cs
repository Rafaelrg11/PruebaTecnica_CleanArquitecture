using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.DTOs.Person;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Infraestructure.Repository
{
    internal sealed class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext context) 
            : base(context) 
        {
        }

        public async Task<Person> GetPersona(Guid id, CancellationToken cancellationToken)
        {
            var person = await _context.Persons
                .FirstOrDefaultAsync(x => x.IdPersona == id);

            return person;
        }

        public async Task<IEnumerable<PersonDTO>> GetPersonas()
        {
            var result =  await _context.Persons
                .Select(e => new PersonDTO
                {
                    IdPersona = e.IdPersona,
                    Name = new NameDTO(e.Name.value),
                    Genero = new GenrerDTO(e.Genero.Value),
                    Edad = e.Edad.Value,
                    Identificacion = new IdentificationDTO(e.Identificacion.Value),
                    Dirección = new AddressDTO(e.Dirección.Value),
                    Teléfono = e.Teléfono.Value
                })
                .ToListAsync();

            return result;
        }

        public async Task UpdatePersona(Person persona)
        {
            _context.Persons.Update(persona);

            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeletePersona(Person person)
        {
             _context.Remove(person);
        }
    }
}
