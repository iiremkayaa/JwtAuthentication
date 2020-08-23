using FluentValidation;
using Project.JwtProject.Entities.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.JwtProject.Business.ValidationRules.FluentValidation
{
    public class AppUserLoginDtoValidator :AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Username must not be null.");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Password must not be null.");

        }
    }
}
