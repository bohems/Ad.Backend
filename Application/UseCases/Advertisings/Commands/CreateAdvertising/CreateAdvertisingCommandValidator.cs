using FluentValidation;

namespace Application.UseCases.Advertisings.Commands.CreateAdvertising
{
    public class CreateAdvertisingCommandValidator
        : AbstractValidator<CreateAdvertisingCommand>
    {
        public CreateAdvertisingCommandValidator()
        {
            RuleFor(createAdvertisingCommand =>
                createAdvertisingCommand.Text).NotEmpty();
            RuleFor(createAdvertisingCommand =>
                createAdvertisingCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
