using AutoMapper;
using Onion.Business.Dtos.DepartmentDtos;
using Onion.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Business.Profiles
{
    internal class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentGetDto>().ReverseMap();
            CreateMap<Department, DepartmentCreateDto>().ReverseMap();
            CreateMap<Department, DepartmentUpdateDto>().ReverseMap();
        }
    }
}
