using Application.Common.Sieve;

namespace Application.UseCases.Advertisings.Queries.GetAdvertisings
{
    public class GetAdvertisingsCollection
    {
        public PagedList<GetAdvertisingsElement> PagedList { get; set; }
    }
}
