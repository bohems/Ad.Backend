using FluentValidation;

namespace Application.UseCases.Advertisings.Commands.UpdateAdvertising
{
    public class UpdateAdvertisingCommandValidation : AbstractValidator<UpdateAdvertisingCommand>
    {
        public UpdateAdvertisingCommandValidation()
        {
            RuleFor(updateAdvertisingCommand =>
                updateAdvertisingCommand.Id).NotEqual(Guid.Empty).NotEmpty();
            RuleFor(updateAdvertisingCommand =>
                updateAdvertisingCommand.Text).NotEmpty();
        }
    }
}
