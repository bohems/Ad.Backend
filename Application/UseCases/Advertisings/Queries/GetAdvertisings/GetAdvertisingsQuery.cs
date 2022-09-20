using Application.Common.Sieve;
using MediatR;

namespace Application.UseCases.Advertisings.Queries.GetAdvertisings
{
    public class GetAdvertisingsQuery : SieveModel, IRequest<GetAdvertisingsCollection> 
    {
    }
}
