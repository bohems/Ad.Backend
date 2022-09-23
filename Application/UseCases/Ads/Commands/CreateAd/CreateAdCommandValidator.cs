using FluentValidation;

namespace Application.UseCases.Ads.Commands.CreateAd
{
    public class CreateAdCommandValidator
        : AbstractValidator<CreateAdCommand>
    {
        public CreateAdCommandValidator()
        {
            RuleFor(command =>
                command.Text).NotEmpty();

            RuleFor(command =>
                command.UserId).NotEqual(Guid.Empty);
        }
    }
}
