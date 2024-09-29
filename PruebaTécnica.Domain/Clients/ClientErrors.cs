using PruebaTécnica.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.Clients
{
    public static class ClientErrors
    {
        public static Error NotFound = new(
           "Client.Found",
           "The client with the specified identifier was not found");
    }
}

