using FluentValidation;
using Project.JwtProject.Entities.Concrete;
using Project.JwtProject.Entities.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.JwtProject.Business.ValidationRules.FluentValidation
{
    public class ProductUpdateDtoValidator :AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(I => I.Id).InclusiveBetween(0, int.MaxValue);
            RuleFor(I => I.Name).NotEmpty().WithMessage("Name must not be empty.");
        }
    }
}
