using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Onion.Business.Dtos.ResultDtos;
using Onion.Business.Dtos.UserDtos;
using Onion.Business.Exceptions;
using Onion.Business.Services.Abstractions;
using Onion.Core.Entities;
using Onion.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Business.Services.Implementations
{
    internal class AuthService(UserManager<AppUser> _userManager, IMapper _mapper) : IAuthService
    {
        public async Task<ResultDto> RegisterAsync(RegisterDto dto)
        {
            var isExistEmail = await _userManager.Users.AnyAsync(x => x.Email!.ToLower() == dto.Email.ToLower());

            var appUser = _mapper.Map<AppUser>(dto);

            var result = await _userManager.CreateAsync(appUser, dto.Password);

            if (!result.Succeeded)
            {
                string message = string.Join(",\n", result.Errors.Select(x => x.Description));

                throw new RegisterException(message);
            }

            await _userManager.AddToRoleAsync(appUser, IdentityRoles.Member.ToString());

            return new();

        }
    }
}
