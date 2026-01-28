using AutoMapper;
using Onion.Business.Dtos.EmployeeDtos;
using Onion.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Business.Profiles
{
    internal class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeGetDto>().ReverseMap();
            CreateMap<Employee, EmployeeCreateDto>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();
        }
    }
}
