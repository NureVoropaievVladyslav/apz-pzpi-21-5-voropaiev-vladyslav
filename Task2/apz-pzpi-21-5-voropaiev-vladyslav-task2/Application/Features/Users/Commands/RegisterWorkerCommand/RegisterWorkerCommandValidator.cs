namespace Application.Features.Users.Commands.RegisterWorkerCommand;

public class RegisterWorkerCommandValidator : AbstractValidator<RegisterWorkerCommand>
{
    public RegisterWorkerCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Fullname is required")
            .MinimumLength(8).WithMessage("Fullname must be at least 8 characters long.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Provided email is not valid.");
        
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MinimumLength(5).WithMessage("Username must be at least 5 characters long.")
            .Matches("[a-z]+$").WithMessage("Username can contain only lowercase letters.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .MaximumLength(32).WithMessage("Password must not exceed 32 characters.")
            .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"[0-9]+").WithMessage("Password must contain at least one number.")
            .Matches(@"[\!\?\*\.]+").WithMessage("Password must contain at least one special symbol '!,?, *,.'.");
    }
}