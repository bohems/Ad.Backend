using FluentValidation;

namespace Application.UseCases.Users.Commands.CreateUser
{
    public class CreateNodeCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateNodeCommandValidator()
        {
            RuleFor(createUserCommand =>
                createUserCommand.Username).NotEmpty().MaximumLength(20);
            RuleFor(createUserCommand =>
                createUserCommand.Password).NotEmpty();
        }
    }
}
