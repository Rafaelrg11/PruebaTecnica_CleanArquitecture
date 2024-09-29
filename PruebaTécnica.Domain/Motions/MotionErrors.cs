using PruebaTécnica.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.Motions;

public static class MotionErrors
{
    public static Error NotFound = new(
       "Motion.Found",
       "The motion with the specified identifier was not found");
}

