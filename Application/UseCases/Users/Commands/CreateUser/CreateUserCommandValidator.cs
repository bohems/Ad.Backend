using FluentValidation;

namespace Application.UseCases.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(command =>
                command.Username).NotEmpty().MaximumLength(20);
            RuleFor(command =>
                command.Password).NotEmpty();
        }
    }
}
