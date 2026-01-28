using Onion.Business.Dtos;
using Onion.Business.Dtos.DepartmentDtos;
using Onion.Business.Dtos.ResultDtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Onion.Business.Services.Abstractions
{
    public interface IDepartmentService
    {
        Task<ResultDto> CreateAsync(DepartmentCreateDto dto);
        Task<ResultDto> UpdateAsync(DepartmentUpdateDto dto);
        Task<ResultDto> DeleteAsync(Guid id);
        Task<ResultDto<List<DepartmentGetDto>>> GetAllAsync();
        Task<ResultDto<DepartmentGetDto>> GetByIdAsync(Guid id);
    }
}
