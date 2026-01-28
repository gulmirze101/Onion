using Onion.Core.Entities;
using Onion.DataAccess.Context;
using Onion.DataAccess.Repositories.Abstractions;
using Onion.DataAccess.Repositories.Implementations.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.DataAccess.Repositories.Implementations
{
    internal class EmployeeRepository(AppDbContext _context) : Repository<Employee>(_context), IEmployeeRepository
    {

    }
}
