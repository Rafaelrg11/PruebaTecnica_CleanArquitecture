using PruebaTécnica.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.Persons
{
    public static class PersonErrors
    {
        public static Error NotFound = new(
           "Person.Found",
           "The person with the specified identifier was not found");
    }
}
