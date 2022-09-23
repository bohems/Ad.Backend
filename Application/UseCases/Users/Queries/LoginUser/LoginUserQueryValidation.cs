using FluentValidation;

namespace Application.UseCases.Users.Queries.LoginUser
{
    public class LoginUserQueryValidation : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidation()
        {
            RuleFor(query =>
                query.Username).NotEmpty();
            RuleFor(query =>
                query.Password).NotEmpty();
        }
    }
}
