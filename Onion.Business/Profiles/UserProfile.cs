using AutoMapper;
using Onion.Business.Dtos.UserDtos;
using Onion.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Business.Profiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, RegisterDto>().ReverseMap();
        }
    }
}
