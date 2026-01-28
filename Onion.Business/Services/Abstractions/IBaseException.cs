using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Business.Services.Abstractions
{
    public interface IBaseException
    {
        public int StatusCode { get; set; }
    }
}
