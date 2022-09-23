using FluentValidation;

namespace Application.UseCases.Ads.Commands.UpdateAd
{
    public class UpdateAdCommandValidation : AbstractValidator<UpdateAdCommand>
    {
        public UpdateAdCommandValidation()
        {
            RuleFor(command =>
                command.Id).NotEqual(Guid.Empty).NotEmpty();

            RuleFor(command =>
                command.Text).NotEmpty();
        }
    }
}
