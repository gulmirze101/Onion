using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Business.Dtos.EmployeeDtos
{
    public class EmployeeCreateDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public decimal Salary { get; set; }
        public string Position { get; set; } = string.Empty;
        public IFormFile Image { get; set; } = null!;
        public Guid DepartmentId { get; set; }
    }
}
