using FluentValidation;
using OnePieceApi.Models.Dtos;

namespace OnePieceApi.Models.Validators;

public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
{
    public UserLoginDtoValidator()
    {
        RuleFor(x => x.Username)
            .MinimumLength(4);
        RuleFor(x => x.Password)
            .MinimumLength(8);
    }
}