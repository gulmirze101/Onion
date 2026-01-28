using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Business.Exceptions
{
    internal class NotFoundException(string message = "This item is not found") : Exception(message)
    {
    }
}
