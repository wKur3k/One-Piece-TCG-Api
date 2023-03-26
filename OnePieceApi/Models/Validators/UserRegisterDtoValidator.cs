using FluentValidation;
using OnePieceApi.Entities;
using OnePieceApi.Models.Dtos;

namespace OnePieceApi.Models.Validators;

public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
{
    public UserRegisterDtoValidator(AppDbContext dbContext)
    {
        RuleFor(x => x.Username)
            .MinimumLength(4);
        RuleFor(x => x.Password)
            .MinimumLength(8);
        RuleFor(x => x.ConfirmPassword)
            .Equal(e => e.Password)
            .WithMessage("Passwords do not match.");
        RuleFor(x => x.Email)
            .EmailAddress();
        RuleFor(x => x.Username)
            .Custom((value, context) =>
            {
                if (dbContext.Users.Any(u => u.Username == value))
                    context.AddFailure("Username", "Username is taken.");
            });
    }
}