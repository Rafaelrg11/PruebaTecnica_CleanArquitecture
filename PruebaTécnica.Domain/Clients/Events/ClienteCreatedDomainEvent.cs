using PruebaTécnica.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.Clientes.Events;

public record ClienteCreatedDomainEvent(Guid Guid) : IDomainEvent;
