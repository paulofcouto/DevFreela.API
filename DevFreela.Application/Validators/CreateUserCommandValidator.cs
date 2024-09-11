using DevFreela.Application.Commands.CreateUser;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator() 
        { 
            RuleFor(t => t.Email).NotEmpty().EmailAddress().WithMessage("Email não válido!");

            RuleFor(usuario => usuario.Password)
                           .NotEmpty().WithMessage("Senha é obrigatória.")
                           .Matches(@"^.*(?=.{8,})(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).+$")
                           .WithMessage("A senha deve conter pelo menos 8 digitos, sendo: uma letra maiúscula, uma letra minúscula, um número e um caractere especial.");
        }
    }
}
