using CookManagement.VSA.Features.Users.CreateUser;
using FluentValidation;

namespace CookManagement.VSA.Shared.Validators;

public class UserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public UserRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long.")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
            .MaximumLength(50).WithMessage("Password cannot exceed 50 characters.");

        RuleFor(x => x.Role)
            .IsInEnum().WithMessage("Invalid user role specified.");
    }
}
