using Onion.Business.Dtos.ResultDtos;
using Onion.Business.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Business.Services.Abstractions
{
    public interface IAuthService
    {
        Task<ResultDto> RegisterAsync(RegisterDto dto);
    }
}
