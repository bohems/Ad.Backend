using MediatR;

namespace Application.UseCases.Advertisings.Commands.DeleteAdvertising
{
    public class DeleteAdvertisingCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
