using FluentValidation;
using FluentValidation.Results;

namespace Restaurant.Data.ViewModel
{
    public class AuthViewModel
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        public ValidationResult Validate()
        {
            var validator = new InlineValidator<AuthViewModel>();

            validator.RuleFor(p => p.Email)
                .NotEmpty()
                .WithMessage("[Email] is required");

            validator.RuleFor(p => p.Email)
                .MaximumLength(320)
                .WithMessage("[Email] cannot have more than 320 characters");

             validator.RuleFor(p => p.Password)
                .NotEmpty()
                .WithMessage("[Password] is required");

             validator.RuleFor(p => p.Password)
                .MinimumLength(8)
                .WithMessage("[Password] cannot have less than 8 characters");

            validator.RuleFor(p => p.Password)
                .MaximumLength(12)
                .WithMessage("[Password] cannot have more than 12 characters");

            return validator.Validate(this);
        }
    }
}
