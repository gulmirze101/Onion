using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Onion.Business.Dtos.DepartmentDtos;
using Onion.Business.Exceptions;
using Onion.Business.Services.Abstractions;
using Onion.Core.Entities;
using Onion.DataAccess.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Business.Services.Implementations
{
    internal class DepartmentService(IDepartmentRepository _repository, IMapper _mapper) : IDepartmentService
    {
        public async Task CreateAsync(DepartmentCreateDto dto)
        {

            var isExistDepartment = await _repository.AnyAsync(x => x.Name.ToLower() == dto.Name.ToLower());

            if (isExistDepartment)
                throw new AlreadyExistsException();

            var department = _mapper.Map<Department>(dto);


            await _repository.AddAsync(department);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var department = await _repository.GetByIdAsync(id);

            if (department is null)
                throw new NotFoundException();

            _repository.DeleteAsync(department);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<DepartmentGetDto>> GetAllAsync()
        {
            var departments = await _repository.GetAll().Include(x => x.Employees).ToListAsync();

            var dtos = _mapper.Map<List<DepartmentGetDto>>(departments);

            return dtos;
        }

        public async Task<DepartmentGetDto> GetByIdAsync(Guid id)
        {
            var department = await _repository.GetByIdAsync(id);

            if (department is null)
                throw new NotFoundException();

            var dto = _mapper.Map<DepartmentGetDto>(department);

            return dto;
        }

        public async Task UpdateAsync(DepartmentUpdateDto dto)
        {
            var department = await _repository.GetByIdAsync(dto.Id);

            if (department is null)
                throw new NotFoundException();

            var isExistDepartment = await _repository.AnyAsync(x => x.Name.ToLower() == dto.Name.ToLower() && x.Id != dto.Id);

            if (isExistDepartment)
                throw new AlreadyExistsException();

            department = _mapper.Map<DepartmentUpdateDto, Department>(dto, department);

            _repository.UpdateAsync(department);
            await _repository.SaveChangesAsync();
        }
    }
}
