   using MediatR;

namespace Application.UseCases.Ads.Commands.CreateAd
{
    public class CreateAdCommand : IRequest<Guid>
    {
        public string Text { get; set; }
        public string? ImageUrl { get; set; }
        public Guid UserId { get; set; }
    }
}
