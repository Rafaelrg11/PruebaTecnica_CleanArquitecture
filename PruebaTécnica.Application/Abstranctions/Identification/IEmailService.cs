using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Abstranctions.Identification;

public interface IEmailService
{
    Task SendAsync(Domain.Persons.Name name, string subject, string body);
}
