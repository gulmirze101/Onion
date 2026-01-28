using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Business.Dtos.DepartmentDtos
{
    public class DepartmentGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
