using FluentValidation;
using FluentValidation.Results;
using Restaurant.Data.Models;

namespace Restaurant.Data.ViewModel
{
    public class MenuItemViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
        public Menu Menu { get; set; }

        public ValidationResult Validate()
        {
            var validator = new InlineValidator<MenuItemViewModel>();

            validator.RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("[Description] is required");

            validator.RuleFor(p => p.Description)
                .MaximumLength(80)
                .WithMessage("[Description] Cannot have more than 80 characters");

            validator.RuleFor(p => p.Menu.Id)
                .GreaterThan(0)
                .WithMessage("[Menu] is required");

            validator.RuleFor(p => p.Product.Id)
                .GreaterThan(0)
                .WithMessage("[Product] is required");

            return validator.Validate(this);
        }
    }
}
