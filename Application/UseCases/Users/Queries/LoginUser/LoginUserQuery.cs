using MediatR;

namespace Application.UseCases.Users.Queries.LoginUser
{
    public class LoginUserQuery : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
