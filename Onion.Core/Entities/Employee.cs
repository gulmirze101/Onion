using Onion.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Core.Entities
{
    public class Employee : BaseAuditableEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string ImagePath{ get; set; } = string.Empty;
        public decimal Salary { get; set; } 
        
        public Guid DepartmentId { get; set;}
        public Department Department { get; set; } = null!;
    }
}
