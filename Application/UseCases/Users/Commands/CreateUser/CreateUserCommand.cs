using MediatR;

namespace Application.UseCases.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
