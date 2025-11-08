using System.Text.RegularExpressions;
using F358.Services.User.Dto;
using FluentValidation;

namespace F358.Services.User.Core.Validators;

internal class NewUserDtoValidator : AbstractValidator<NewUserDto>
{
    private static readonly Regex LoginRegex = new("[a-zA-Z0-9_.]*");
    private const int LoginMaxLength = 50;
    private const int PasswordMinLength = 6;
    private const int PasswordMaxLength = 500;
    
    public NewUserDtoValidator()
    {
        RuleFor(dto => dto.Login)
            .NotNull().WithMessage("Login is required.")
            .NotEmpty().WithMessage("Login is required.")
            .MaximumLength(50).WithMessage($"Login maximum length is {LoginMaxLength} characters.")
            .Matches(LoginRegex)
                .WithMessage("Login can contain only latin letters, numbers and symbols: \"_\" and \".\".");

        //TODO: password req?
        RuleFor(dto => dto.Password)
            .NotNull().WithMessage("Password is required.")
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(PasswordMinLength).WithMessage($"Password minimum length is {PasswordMinLength}.")
            .MaximumLength(PasswordMaxLength).WithMessage($"Password maximum length is {PasswordMaxLength}.");

        RuleFor(dto => dto.FirstName)
            .NotNull().WithMessage("First name is required.")
            .NotEmpty().WithMessage("First name is required.");
    }
}