using Onion.Core.Entities;
using Onion.DataAccess.Context;
using Onion.DataAccess.Repositories.Abstractions;
using Onion.DataAccess.Repositories.Implementations.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.DataAccess.Repositories.Implementations
{
    internal class DepartmentRepository(AppDbContext _context) : Repository<Department>(_context), IDepartmentRepository
    {
    }
}
