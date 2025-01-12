using FluentValidation;
using FluentValidation.Results;
using Restaurant.Data.Models;

namespace Restaurant.Data.ViewModel
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string ImageBase64 { get; set; }
        public string BadgeDescription { get; set; }
        public string BadgeColor { get; set; }
        //public IList<MenuItem> MenuItem { get; set; }

        public ValidationResult Validate()
        {
            var validator = new InlineValidator<MenuViewModel>();

            validator.RuleFor(p => p.Title)
                .NotEmpty()
                .WithMessage("[Title] is required");

            validator.RuleFor(p => p.Description)
                .MaximumLength(35)
                .WithMessage("[Title] Cannot have more than 35 characters");

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
