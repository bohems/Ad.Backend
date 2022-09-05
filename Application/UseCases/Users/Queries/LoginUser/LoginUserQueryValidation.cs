using FluentValidation;

namespace Application.UseCases.Users.Queries.LoginUser
{
    public class LoginUserQueryValidation : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidation()
        {
            RuleFor(loginUserQuery =>
                loginUserQuery.Username).NotEmpty();
            RuleFor(loginUserQuery =>
                loginUserQuery.Password).NotEmpty();
        }
    }
}
