using PruebaTécnica.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.Motions.Events
{
    public record class MotionCreatedDomainEvent(Guid Guid) : IDomainEvent;
    
    
}
