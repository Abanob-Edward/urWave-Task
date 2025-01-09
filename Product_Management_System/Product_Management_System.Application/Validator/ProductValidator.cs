using FluentValidation;
using Product_Management_System.Dtos.Product;
using Product_Management_System.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management_System.Application.Validator
{
    public class AddOrUpdateProductDtoValidator : AbstractValidator<AddOrUpdateProductDto>
    {
        public AddOrUpdateProductDtoValidator()
        {
            RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(dto => dto.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(dto => dto.Price)
                .NotEmpty().WithMessage("Price is required.")
                .GreaterThan(0).WithMessage("Price must be a positive number.");
        }
    }
}
