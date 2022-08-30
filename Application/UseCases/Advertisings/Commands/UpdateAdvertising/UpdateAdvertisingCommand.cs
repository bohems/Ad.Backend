using MediatR;

namespace Application.UseCases.Advertisings.Commands.UpdateAdvertising
{
    public class UpdateAdvertisingCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string? ImageUrl { get; set; }
    }
}
