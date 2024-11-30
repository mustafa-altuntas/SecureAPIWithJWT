using AuthServer.Core.Dtos;
using FluentValidation;

namespace AuthServer.API.Validations.User
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {

        public CreateUserDtoValidator()
        {
            RuleFor(u => u.UserName)
                .NotEmpty().WithMessage("Kullanıcı Adını girmediniz.")
                .NotNull().WithMessage("Kullanıcı Adını girmediniz.");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Şifre girmediniz.")
                .NotNull().WithMessage("Şifre girmediniz.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email girmediniz.")
                .NotNull().WithMessage("Email girmediniz.")
                .EmailAddress().WithMessage("Email alanına geçersiz bir giriş yaptınız.");


        }
    }
}
