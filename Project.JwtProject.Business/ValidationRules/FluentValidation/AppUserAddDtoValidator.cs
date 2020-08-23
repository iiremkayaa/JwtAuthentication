using FluentValidation;
using Project.JwtProject.Entities.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.JwtProject.Business.ValidationRules.FluentValidation
{
    public class AppUserAddDtoValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddDtoValidator()
        {
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Username must not be null.");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Password must not be null.");
            RuleFor(I => I.FullName).NotEmpty().WithMessage("Fullname must not be null.");
        }
    }
}
