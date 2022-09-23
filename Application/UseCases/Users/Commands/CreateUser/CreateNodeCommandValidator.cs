using FluentValidation;

namespace Application.UseCases.Users.Commands.CreateUser
{
    public class CreateNodeCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateNodeCommandValidator()
        {
            RuleFor(command =>
                command.Username).NotEmpty().MaximumLength(20);
            RuleFor(command =>
                command.Password).NotEmpty();
        }
    }
}
