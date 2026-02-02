using FluentValidation;
using Onion.Business.Dtos.EmployeeDtos;
using Onion.Business.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Business.Validators.EmployeeValidators
{
    public class EmployeeCreateDtoValidator : AbstractValidator<EmployeeCreateDto>
    {
        public EmployeeCreateDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().MaximumLength(256).WithMessage("Maximum size 256 ola biler")
                .MinimumLength(3);

            RuleFor(x => x.LastName).NotEmpty().MaximumLength(256).WithMessage("Maximum size 256 ola biler")
                 .MinimumLength(3);


            RuleFor(x => x.Image)
            .Must(x => x.CheckSize(2)).WithMessage("Image maximum size must be 2 mb")
            .Must(x => x.CheckType("image")).WithMessage("You can only upload with image format");
        }
    }
}
