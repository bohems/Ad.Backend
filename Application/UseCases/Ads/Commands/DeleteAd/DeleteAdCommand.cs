using MediatR;

namespace Application.UseCases.Ads.Commands.DeleteAd
{
    public class DeleteAdCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
