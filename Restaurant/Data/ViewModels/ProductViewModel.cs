using FluentValidation;
using FluentValidation.Results;

namespace Restaurant.Data.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int IdCategory { get; set; }

        public ValidationResult Validate()
        {
            var validator = new InlineValidator<ProductViewModel>();

            validator.RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("[Name] is required");

            validator.RuleFor(p => p.Name)
                .MaximumLength(35)
                .WithMessage("[Name] Cannot have more than 35 characters");

            validator.RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("[Description] is required");

            validator.RuleFor(p => p.Description)
                .MaximumLength(80)
                .WithMessage("[Description] Cannot have more than 80 characters");

            validator.RuleFor(p => p.Price)
                .NotEmpty()
                .WithMessage("[Price] is required");

            validator.RuleFor(p => p.IdCategory)
                .NotNull()
                .WithMessage("[Category] is required");

            return validator.Validate(this);
        }
    }
}
