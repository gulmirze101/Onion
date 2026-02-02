using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.DataAccess.Abstractions
{
    public   interface IContextInitializer
    {
        Task InitDatabaseAsync();
    }
}
