using Application.Common.Sieve;

namespace Application.UseCases.Ads.Queries.GetAds
{
    public class GetAdCollection
    {
        public PagedList<GetAdElement> PagedList { get; set; }
    }
}
