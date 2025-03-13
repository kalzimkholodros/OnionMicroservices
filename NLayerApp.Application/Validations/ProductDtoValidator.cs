using FluentValidation;
using NLayerApp.Core.DTOs;

namespace NLayerApp.Application.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters");

            RuleFor(x => x.Price)
                .NotNull().WithMessage("{PropertyName} is required")
                .InclusiveBetween(1, decimal.MaxValue).WithMessage("{PropertyName} must be greater than 0");

            RuleFor(x => x.Stock)
                .NotNull().WithMessage("{PropertyName} is required")
                .InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0");

            RuleFor(x => x.CategoryId)
                .NotNull().WithMessage("{PropertyName} is required")
                .InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0");
        }
    }
} 