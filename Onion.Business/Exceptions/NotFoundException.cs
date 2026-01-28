using Onion.Business.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Business.Exceptions
{
    internal class NotFoundException(string message = "This item is not found") : Exception(message), IBaseException
    {
        public int StatusCode { get; set; } = 404;
    }
}
