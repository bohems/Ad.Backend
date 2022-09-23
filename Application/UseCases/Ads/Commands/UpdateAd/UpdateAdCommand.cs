using MediatR;

namespace Application.UseCases.Ads.Commands.UpdateAd
{
    public class UpdateAdCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public string? ImageUrl { get; set; }
    }
}
