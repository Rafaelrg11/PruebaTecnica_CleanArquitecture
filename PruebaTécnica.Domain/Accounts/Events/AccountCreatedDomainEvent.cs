using PruebaTécnica.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.Accounts.Events;

public record AccountCreatedDomainEvent(Guid Guid) : IDomainEvent;


