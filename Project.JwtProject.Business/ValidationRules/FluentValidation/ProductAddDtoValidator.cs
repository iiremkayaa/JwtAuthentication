using FluentValidation;
using Project.JwtProject.Entities.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.JwtProject.Business.ValidationRules.FluentValidation
{
    public class ProductAddDtoValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Name must not be null.");
        }
    }
}
