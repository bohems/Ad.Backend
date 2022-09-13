using MediatR;
using Sieve.Models;

namespace Application.UseCases.Advertisings.Queries.GetAdvertisings
{
    public class GetAdvertisingsQuery : IRequest<GetAdvertisingsCollection> 
    {
        public SieveModel SieveModel { get; set; }
    }
}
