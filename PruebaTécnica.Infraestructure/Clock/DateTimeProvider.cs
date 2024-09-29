using PruebaTécnica.Application.Abstranctions.Clock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Infraestructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{ 
    public DateTime UtcNow => DateTime.UtcNow;
}
