using Application.Common.Sieve;
using MediatR;

namespace Application.UseCases.Ads.Queries.GetAds
{
    public class GetAdsQuery : SieveModel, IRequest<GetAdCollection> 
    {
    }
}
