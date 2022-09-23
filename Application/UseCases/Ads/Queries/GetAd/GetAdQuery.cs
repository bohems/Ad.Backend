using MediatR;

namespace Application.UseCases.Ads.Queries.GetAd
{
    public class GetAdQuery : IRequest<GetAdResponse>
    {
        public Guid Id { get; set; }
    }
}
