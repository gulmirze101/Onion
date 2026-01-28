using Onion.Business.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Business.Exceptions
{
    internal class AlreadyExistsException(string message="This item already exists") : Exception(message), IBaseException
    {
        public int StatusCode { get; set; } = 409;
    }
}
