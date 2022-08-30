using MediatR;

namespace Application.UseCases.Advertisings.Commands.CreateAdvertising
{
    public class CreateAdvertisingCommand : IRequest<Guid>
    {
        public string Text { get; set; }
        public string? ImageUrl { get; set; }
        public Guid UserId { get; set; }
    }
}
