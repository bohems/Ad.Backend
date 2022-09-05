using FluentValidation;

namespace Application.UseCases.Advertisings.Commands.DeleteAdvertising
{
    public class DeleteAdvertisingCommandValidation : AbstractValidator<DeleteAdvertisingCommand>
    {
        public DeleteAdvertisingCommandValidation()
        {
            RuleFor(deleteAdvertisingCommand => 
                deleteAdvertisingCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteAdvertisingCommand => 
                deleteAdvertisingCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
