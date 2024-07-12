using FluentValidation;
using FluentValidation.Results;

namespace Restaurant.Data.ViewModel
{
    public class CategoryViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ValidationResult Validate()
        {
            var validator = new InlineValidator<CategoryViewModel>();

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

            return validator.Validate(this);
        }
    }
}
