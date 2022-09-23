using FluentValidation;

namespace Application.UseCases.Ads.Commands.DeleteAd
{
    public class DeleteAdCommandValidation : AbstractValidator<DeleteAdCommand>
    {
        public DeleteAdCommandValidation()
        {
            RuleFor(command =>
                command.Id).NotEqual(Guid.Empty);
            RuleFor(command =>
                command.UserId).NotEqual(Guid.Empty);
        }
    }
}
