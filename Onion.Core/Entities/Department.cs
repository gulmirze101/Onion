using Onion.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Core.Entities
{
    public  class Department : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Employee> Employees { get; set; } = [];
    }
}
